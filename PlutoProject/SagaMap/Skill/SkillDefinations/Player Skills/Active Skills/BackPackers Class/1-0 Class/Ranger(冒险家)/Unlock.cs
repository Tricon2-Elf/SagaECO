using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SagaDB.Actor;
using SagaLib;
using SagaMap.Network.Client;
using SagaMap.Skill.Additions.Global;

namespace SagaMap.Skill.SkillDefinations.Ranger
{
    public class Unlock : Skill.SkillDefinations.Global.SkillEvent
    {
        protected override void RunScript(SagaMap.Skill.SkillDefinations.Global.SkillEvent.Parameter para)
        {
            Scripting.SkillEvent.Instance.OpenTreasureBox((ActorPC)para.sActor);
        }
    }
}
