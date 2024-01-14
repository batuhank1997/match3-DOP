using System.Collections.Generic;
using _Dev.Providers;
using _Dev.Scripts.Data;

namespace _Dev.Scripts
{
    public static class ItemContainer
    {
        private static readonly SpriteProvider _spriteProvider = ServiceLocator.Instance.Get<SpriteProvider>();
        
        private static readonly Dictionary<ItemType, ItemData> _itemDataDictionary = new ()
        {
            {ItemType.Invalid, new ItemData(ItemType.Invalid, new SpriteData(_spriteProvider.InValid))},
            {ItemType.Red, new ItemData(ItemType.Red, new SpriteData(_spriteProvider.Red))},
            {ItemType.Blue, new ItemData(ItemType.Blue, new SpriteData(_spriteProvider.Blue))},
            {ItemType.Green, new ItemData(ItemType.Green, new SpriteData(_spriteProvider.Green))},
            {ItemType.Yellow, new ItemData(ItemType.Yellow, new SpriteData(_spriteProvider.Yellow))},
            {ItemType.Purple, new ItemData(ItemType.Purple, new SpriteData(_spriteProvider.Purple))},
            {ItemType.Pink, new ItemData(ItemType.Pink, new SpriteData(_spriteProvider.Pink))},
        };
        
        public static ItemData GetItemDataByType(ItemType itemType)
        {
            return _itemDataDictionary[itemType];
        }
    }
}