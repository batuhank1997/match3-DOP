using _Dev.Scripts.Enums;

namespace _Dev.Scripts.Data
{
    public abstract class ItemSkill
    {
        public abstract SkillType SkillType { get; }
        public abstract void BlastWithSkill();

    }
}