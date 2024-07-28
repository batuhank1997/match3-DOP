using _Dev.Scripts.Data;
using _Dev.Scripts.Enums;
using _Dev.Scripts.Skills;
using UnityEngine;
using ItemSkill = _Dev.Scripts.Data.ItemSkill;

namespace _Dev.Scripts.GameUtilities
{
    public static class CellUtility
    {
        public static bool IsEmpty(this Cell cell)
        {
            return cell.ItemData.ItemType == ItemType.Empty;
        }

        public static void BlastCell(this Cell cell)
        {
            cell.ItemData = new ItemData(ItemType.Empty);
        }
        
        public static ItemSkill GetItemSpecificationForBlast(byte blastSize)
        {
            return blastSize switch
            {
                1 => new NoSkill(),
                2 => new NoSkill(),
                3 => new BasicBomb(),
                4 => new TwoDirectionalRocket(),
                _ => new Disco(),
            };
        }
        
        public static Sprite GetItemSpriteBySpecification(this Cell cell)
        {
            var key = (cell.ItemData.ItemType, cell.GetSkill().SkillType);

            if (!SpriteContainer.TryGetSpecificSprite(key, out var sprite))
                return SpriteContainer.GetSpriteByItemType(cell.ItemData.ItemType);

            return sprite;
        }
    }
}