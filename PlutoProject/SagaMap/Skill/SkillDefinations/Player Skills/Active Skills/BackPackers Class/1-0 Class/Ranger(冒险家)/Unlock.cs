using SagaDB.Actor;

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
