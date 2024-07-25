using System;
using _Dev.Scripts.Data;
using _Dev.Scripts.Enums;
using UnityEngine;

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
        
        public static ItemSpecification GetItemSpecificationForBlast(byte blastSize)
        {
            return blastSize switch
            {
                1 => new ItemSpecification(ItemSkill.None),
                2 => new ItemSpecification(ItemSkill.None),
                3 => new ItemSpecification(ItemSkill.BasicBomb),
                4 => new ItemSpecification(ItemSkill.TwoDirectionalRocket),
                _ => new ItemSpecification(ItemSkill.Disco),
            };
        }
        
        public static Sprite GetItemSpriteBySpecification(this Cell cell)
        {
            var key = (cell.ItemData.ItemType, cell.ItemSpecification.ItemSkill);

            if (!SpriteContainer.TryGetSpecificSprite(key, out var sprite))
                return SpriteContainer.GetSpriteByItemType(cell.ItemData.ItemType);

            return sprite;
        }
    }
}