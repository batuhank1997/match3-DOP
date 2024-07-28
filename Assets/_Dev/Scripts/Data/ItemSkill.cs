using _Dev.Scripts.Enums;

namespace _Dev.Scripts.Data
{
    public abstract class ItemSkill
    {
        public abstract SkillType SkillType { get; }
        public abstract void BlastWithSkill();

    }
    
    public class NoSkill : ItemSkill
    {
        public override SkillType SkillType => SkillType.None;
        
        public override void BlastWithSkill()
        {
            // Do something
        }
    }
    
    public class BasicBomb : ItemSkill
    {
        public override SkillType SkillType => SkillType.BasicBomb;
        
        public override void BlastWithSkill()
        {
            // Do something
        }
    }
    
    public class TwoDirectionalRocket : ItemSkill
    {
        public override SkillType SkillType => SkillType.TwoDirectionalRocket;
        
        public override void BlastWithSkill()
        {
            // Do something
        }
    }
    
    public class Disco : ItemSkill
    {
        public override SkillType SkillType => SkillType.Disco;
        
        public override void BlastWithSkill()
        {
            // Do something
        }
    }
}