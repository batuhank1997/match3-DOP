using _Dev.Scripts.Data;
using _Dev.Scripts.Enums;

namespace _Dev.Scripts.Skills
{
    public class NoSkill : ItemSkill
    {
        public override SkillType SkillType => SkillType.None;
        
        public override void BlastWithSkill()
        {
            // Do something
        }
    }
}