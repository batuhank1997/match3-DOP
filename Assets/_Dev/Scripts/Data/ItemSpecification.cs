using _Dev.Scripts.Enums;

namespace _Dev.Scripts.Data
{
    public readonly struct ItemSpecification
    {
        public readonly ItemSkill ItemSkill;

        public ItemSpecification(ItemSkill itemSkill)
        {
            ItemSkill = itemSkill;
        }
        
        public static ItemSpecification Invalid => new(ItemSkill.Invalid);
    }
}