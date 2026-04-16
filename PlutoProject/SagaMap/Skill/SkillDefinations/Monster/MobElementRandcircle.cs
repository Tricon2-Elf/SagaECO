using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SagaDB.Actor;
using SagaLib;
using SagaMap;
using SagaMap.Skill.SkillDefinations.Global;

namespace SagaMap.Skill.SkillDefinations.Monster
{
    /// <summary>
    /// 各種精靈的憤怒
    /// </summary>
    public class MobElementRandcircle : ISkill
    {
        private uint NextSkillID = 0;
        private int Count;

        public MobElementRandcircle(uint NextID, int count)
        {
            NextSkillID = NextID;
            Count = count;
        }

        #region ISkill Members
        public int TryCast(ActorPC sActor, Actor dActor, SkillArg args)
        {
            return 0;
        }

        public void Proc(Actor sActor, Actor dActor, SkillArg args, byte level)
        {
            for (int i = 0; i < Count; i++)
            {
                args.autoCast.Add(SkillHandler.Instance.CreateAutoCastInfo(NextSkillID, level, 0));
            }
        }
        #endregion
    }
}
