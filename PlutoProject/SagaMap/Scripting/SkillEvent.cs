using System;
using SagaDB.Actor;

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
