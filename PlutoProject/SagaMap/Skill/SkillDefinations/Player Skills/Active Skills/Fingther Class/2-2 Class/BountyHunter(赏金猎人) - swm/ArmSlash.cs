using SagaDB.Actor;

namespace SagaMap.Skill.SkillDefinations.BountyHunter
{
    /// <summary>
    /// 砍擊武器（アームスラッシュ）
    /// </summary>
    public class ArmSlash : Slash, ISkill
    {
        #region ISkill Members
        public void Proc(Actor sActor, Actor dActor, SkillArg args, byte level)
        {
            this.SkillProc(sActor, dActor, args, level, SagaLib.PossessionPosition.RIGHT_HAND);
        }
        #endregion
    }
}
