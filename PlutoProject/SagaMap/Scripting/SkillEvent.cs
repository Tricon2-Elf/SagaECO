using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SagaDB.Actor;
using SagaDB.Map;
using SagaLib;
using SagaMap;
using SagaMap.Network.Client;

namespace SagaMap.Scripting
{
    public class SkillEvent : Event
    {
        static SkillEvent instance;

        public static SkillEvent Instance
        {
            get
            {
                if (instance == null)
                    instance = new SkillEvent();
                return instance;
            }
        }

        public override void OnEvent(ActorPC pc)
        {
            throw new NotImplementedException();
        }
    }
}
