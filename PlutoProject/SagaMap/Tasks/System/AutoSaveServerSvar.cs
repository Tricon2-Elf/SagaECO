using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using SagaDB.Actor;
using SagaLib;
using SagaMap.Manager;
using SagaMap.Network.Client;

namespace SagaMap.Tasks.System
{
    public class AutoSaveServerSvar : MultiRunTask
    {
        public AutoSaveServerSvar()
        {
            this.period = 120000;
        }

        public override void CallBack()
        {
            //ClientManager.EnterCriticalArea();
            try
            {
                Logger.ShowInfo("Autosaving Server Svar data...");
                MapServer.charDB.SaveServerVar(ScriptManager.Instance.VariableHolder);
            }
            catch (Exception ex)
            {
                Logger.ShowError(ex);
            }
            //ClientManager.LeaveCriticalArea();
        }
    }
}
