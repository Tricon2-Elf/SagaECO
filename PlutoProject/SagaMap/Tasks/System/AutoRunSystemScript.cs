using SagaLib;
using SagaMap.Manager;

namespace SagaMap.Tasks.System
{
    public class AutoRunSystemScript : MultiRunTask
    {
        uint ID = 0;

        public AutoRunSystemScript(uint EventID)
        {
            this.period = 5000;
            this.dueTime = 10000;
            ID = EventID;
        }

        public override void CallBack()
        {
            if (ScriptManager.Instance.Events.ContainsKey(ID))
            {
                Scripting.Event evnt = ScriptManager.Instance.Events[ID];
                evnt.OnEvent(ScriptManager.Instance.VariableHolder);
                Logger.ShowInfo("已成功加載腳本：" + evnt.ToString());
            }
            this.Deactivate();
        }
    }
}
