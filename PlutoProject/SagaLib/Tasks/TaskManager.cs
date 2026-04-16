using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace SagaLib
{
    public class TaskManager : Singleton<TaskManager>
    {
        List<Thread> threadpool = new List<Thread>();
        ConcurrentQueue<MultiRunTask> fifo = new ConcurrentQueue<MultiRunTask>();
        ConcurrentQueue<MultiRunTask> slowFifo = new ConcurrentQueue<MultiRunTask>();
        AutoResetEvent waiter = new AutoResetEvent(false);
        AutoResetEvent waiterSlow = new AutoResetEvent(false);
        HashSet<MultiRunTask> registered = new HashSet<MultiRunTask>();
        int exeCount;
        int exeTime;
        DateTime exeStamp = DateTime.Now,
            schedulerStamp = DateTime.Now;
        int schedulerTime;
        int schedulerCount;
        Stopwatch watch = new Stopwatch();
        MultiRunTask[] tasks = new MultiRunTask[0];

        public int AverageScheduleTime { get; set; }

        public int AverageExecutionTime { get; set; }

        public int RegisteredCount
        {
            get { return registered.Count; }
        }

        public int ExecutionCountPerMinute { get; set; }
        Thread main;

        public TaskManager()
        {
            SetWorkerCount(4, 8);
            Start();
        }

        public void SetWorkerCount(int count, int slowCount)
        {
            foreach (Thread i in threadpool)
            {
                ClientManager.RemoveThread(i.Name);
                i.Abort();
            }
            threadpool.Clear();
            for (int i = 0; i < count; i++)
            {
                Thread thread = new Thread(Worker);
                thread.Priority = ThreadPriority.Highest;
                thread.Name = string.Format("Worker({0})", thread.ManagedThreadId);
                ClientManager.AddThread(thread);
                thread.Start();
                threadpool.Add(thread);
            }
            for (int i = 0; i < slowCount; i++)
            {
                Thread thread = new Thread(WorkerSlow);
                thread.Name = string.Format("WorkerSlow({0})", thread.ManagedThreadId);
                ClientManager.AddThread(thread);
                thread.Start();
                threadpool.Add(thread);
            }
        }

        public void Start()
        {
            if (main != null)
            {
                ClientManager.RemoveThread(main.Name);
                main.Abort();
            }
            main = new Thread(MainLoop);
            main.Name = string.Format("ThreadPoolMainLoop({0})", main.ManagedThreadId);
            SagaLib.Logger.ShowInfo("主线程启动！：" + main.Name);
            ClientManager.AddThread(main);
            main.Start();
        }

        public void Stop()
        {
            foreach (Thread i in threadpool)
            {
                ClientManager.RemoveThread(i.Name);
                i.Abort();
            }
            threadpool.Clear();
            if (main != null)
            {
                ClientManager.RemoveThread(main.Name);
                main.Abort();
            }
        }

        public void RegisterTask(MultiRunTask task)
        {
            lock (registered)
                registered.Add(task);
        }

        public List<string> RegisteredTasks
        {
            get
            {
                List<string> list = new List<string>();
                lock (registered)
                {
                    foreach (MultiRunTask i in registered)
                    {
                        list.Add(i.ToString());
                    }
                }
                return list;
            }
        }

        public void RemoveTask(MultiRunTask task)
        {
            lock (registered)
                registered.Remove(task);
        }

        void PushTaskes()
        {
            DateTime now = DateTime.Now;
            if ((now - exeStamp).TotalMinutes > 1)
            {
                AverageExecutionTime = exeCount > 0 ? exeTime / exeCount : 0;
                ExecutionCountPerMinute = exeCount;
                Interlocked.Exchange(ref exeCount, 0);
                Interlocked.Exchange(ref exeTime, 0);
                exeStamp = now;
            }
            if ((now - schedulerStamp).TotalMinutes > 1)
            {
                AverageScheduleTime = schedulerCount > 0 ? schedulerTime / schedulerCount : 0;
                Interlocked.Exchange(ref schedulerCount, 0);
                Interlocked.Exchange(ref schedulerTime, 0);
                schedulerStamp = now;
            }
            Interlocked.Increment(ref schedulerCount);
            watch.Restart();
            int length;
            lock (registered)
            {
                int count = registered.Count;
                if (tasks.Length < count)
                    tasks = new MultiRunTask[count];
                length = count;
                registered.CopyTo(tasks);
            }
            for (int i = 0; i < length; i++)
            {
                MultiRunTask task = tasks[i];
                try
                {
                    if (!task.executing && now > task.NextUpdateTime)
                    {
                        task.executing = true;
                        task.NextUpdateTime = now.AddMilliseconds(task.Period);
                        task.TaskBeginTime = now;
                        if (task.IsSlowTask)
                        {
                            slowFifo.Enqueue(task);
                            waiterSlow.Set();
                        }
                        else
                        {
                            fifo.Enqueue(task);
                            waiter.Set();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.ShowError(ex);
                }
            }
            watch.Stop();
            Interlocked.Add(ref schedulerTime, (int)watch.ElapsedMilliseconds);
        }

        private void MainLoop()
        {
            try
            {
                while (true)
                {
                    PushTaskes();
                    if (registered.Count > 1000)
                    {
                        int waitTime = 10000 / registered.Count;
                        if (waitTime > 10)
                            waitTime = 10;
                        if (waitTime == 0)
                            waitTime = 1;
                        Thread.Sleep(waitTime);
                    }
                    else
                        Thread.Sleep(1);
                }
            }
            catch (ThreadAbortException)
            {
                ClientManager.RemoveThread(Thread.CurrentThread.Name);
            }
            catch (Exception ex)
            {
                Logger.ShowError(ex);
            }
            ClientManager.RemoveThread(Thread.CurrentThread.Name);
        }

        void Worker()
        {
            WorkerIntern(fifo, waiter);
        }

        void WorkerSlow()
        {
            WorkerIntern(slowFifo, waiterSlow);
        }

        private void WorkerIntern(ConcurrentQueue<MultiRunTask> fifo, AutoResetEvent waiter)
        {
            try
            {
                while (true)
                {
                    MultiRunTask task;
                    while (fifo.TryDequeue(out task))
                    {
                        try
                        {
                            task.CallBack();
                            Interlocked.Add(ref exeTime, (int)(DateTime.Now - task.TaskBeginTime).TotalMilliseconds);
                            Interlocked.Increment(ref exeCount);
                            task.executing = false;
                        }
                        catch (Exception ex)
                        {
                            Logger.ShowError(ex);
                        }
                    }
                    waiter.WaitOne(5);
                }
            }
            catch (ThreadAbortException)
            {
                ClientManager.RemoveThread(Thread.CurrentThread.Name);
            }
            catch (Exception ex)
            {
                Logger.ShowError("Critical ERROR! Worker terminated unexpected!");
                Logger.ShowError(ex);
            }
            ClientManager.RemoveThread(Thread.CurrentThread.Name);
        }
    }
}
