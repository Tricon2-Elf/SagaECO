using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SagaLib
{
    public abstract class MultiRunTask
    {
        public int dueTime;

        public int period;

        public DateTime NextUpdateTime = DateTime.Now;

        public bool IsSlowTask { get; set; }
        bool activate = false;
        internal bool executing;
        string name;
        internal DateTime TaskBeginTime;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public MultiRunTask() { }

        public MultiRunTask(int dueTime, int period, string name)
        {
            if (period <= 0)
                Logger.ShowWarning("period <= 0");
            this.dueTime = dueTime;
            this.period = period;
            this.name = name;
        }

        public abstract void CallBack();

        protected virtual void OnActivate() { }

        public bool Activated
        {
            get { return activate; }
        }

        public bool getActivated()
        {
            return Activated;
        }

        public int DueTime
        {
            get { return dueTime; }
            set { dueTime = value; }
        }

        public int Period
        {
            get { return period; }
            set { period = value; }
        }

        public void Activate()
        {
            NextUpdateTime = DateTime.Now.AddMilliseconds(dueTime);
            TaskManager.Instance.RegisterTask(this);
            activate = true;
            OnActivate();
        }

        public void Deactivate()
        {
            TaskManager.Instance.RemoveTask(this);
            if (activate)
            {
                activate = false;
                OnDeactivate();
            }
        }

        protected virtual void OnDeactivate() { }
    }
}
