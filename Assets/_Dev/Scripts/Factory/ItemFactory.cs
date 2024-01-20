using System.Collections.Generic;
using _Dev.Scripts.Data;
using _Dev.Scripts.Enums;
using UnityEngine;

namespace _Dev.Scripts.Factory
{
    public static class ItemFactory
    {
        private static readonly Dictionary<ItemType, ItemData> _itemDataDictionary = new ()
        {
            {ItemType.Invalid, new ItemData(ItemType.Invalid)},
            {ItemType.Empty, new ItemData(ItemType.Empty)},
            {ItemType.Red, new ItemData(ItemType.Red)},
            {ItemType.Blue, new ItemData(ItemType.Blue)},
            {ItemType.Green, new ItemData(ItemType.Green)},
            {ItemType.Yellow, new ItemData(ItemType.Yellow)},
            {ItemType.Purple, new ItemData(ItemType.Purple)},
            {ItemType.Pink, new ItemData(ItemType.Pink)},
        };
        
        public static ItemData CreateItemByType(ItemType itemType)
        {
            return _itemDataDictionary[itemType];
        }
        
        public static ItemData CreateRandomItem()
        {
            var randomItemType = (ItemType) Random.Range(1, 7);
            return CreateItemByType(randomItemType);
        }
    }
}