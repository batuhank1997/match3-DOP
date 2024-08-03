using _Dev.Scripts.Data;
using _Dev.Scripts.Enums;
using _Dev.Scripts.Skills;
using UnityEngine;

namespace _Dev.Scripts.GameUtilities
{
    public static class CellUtility
    {
        public static bool IsEmpty(this Cell cell)
        {
            return cell.ItemData.ItemType == ItemType.Empty;
        }
        
        public static bool IsCellItemMoving(this Cell cell)
        {
            return cell.ItemDistance.Value > InGameConstants.Item.StartingItemDistance;
        }

        public static void BlastCell(this Cell cell)
        {
            cell.ItemData = new ItemData(ItemType.Empty);
        }
        
        public static SkillType GetSkillTypeByBlastSize(byte blastSize)
        {
            return blastSize switch
            {
                1 => SkillType.None,
                2 => SkillType.None,
                3 => SkillType.BasicBomb,
                4 => SkillType.TwoDirectionalRocket,
                _ => SkillType.Disco
            };
        }
        
        public static Sprite GetItemSpriteBySpecification(this Cell cell)
        {
            var key = (cell.ItemData.ItemType, cell.PossibleSkillCreationType);

            if (!SpriteContainer.TryGetSpecificSprite(key, out var sprite))
                return SpriteContainer.GetSpriteByItemType(cell.ItemData.ItemType);

            return sprite;
        }
    }
}