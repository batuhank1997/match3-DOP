using _Dev.Scripts.Data;
using _Dev.Scripts.Enums;
using _Dev.Scripts.Skills;

namespace _Dev.Scripts.Factory
{
    public static class SkillFactory
    {
        public static ItemSkill CreateSkillBySkillType(SkillType skillType)
        {
            return skillType switch
            {
                SkillType.None => new NoSkill(),
                SkillType.BasicBomb => new BasicBomb(),
                SkillType.TwoDirectionalRocket => new TwoDirectionalRocket(),
                SkillType.Disco => new Disco(),
                _ => new NoSkill()
            };
        }
    }
}