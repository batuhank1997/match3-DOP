using System.Collections.Generic;
using _Dev.Providers;
using _Dev.Scripts.Data;
using _Dev.Scripts.Enums;
using UnityEngine;

namespace _Dev.Scripts
{
    public static class SpriteContainer
    {
        private static readonly SpriteProvider _spriteProvider = ServiceLocator.Instance.Get<SpriteProvider>();

        private static readonly Dictionary<SpriteId, Sprite> _spriteDataBySpriteId = new()
        {
            {SpriteId.Invalid, _spriteProvider.InValid},
            {SpriteId.Red, _spriteProvider.Red},
            {SpriteId.Blue, _spriteProvider.Blue},
            {SpriteId.Green, _spriteProvider.Green},
            {SpriteId.Yellow, _spriteProvider.Yellow},
            {SpriteId.Purple, _spriteProvider.Purple},
            {SpriteId.Pink, _spriteProvider.Pink},
        };
        
        private static readonly Dictionary<ItemType, Sprite> _spriteDataByItemType = new()
        {
            {ItemType.Invalid, _spriteProvider.InValid},
            {ItemType.Empty, _spriteProvider.InValid},
            {ItemType.Red, _spriteProvider.Red},
            {ItemType.Blue, _spriteProvider.Blue},
            {ItemType.Green, _spriteProvider.Green},
            {ItemType.Yellow, _spriteProvider.Yellow},
            {ItemType.Purple, _spriteProvider.Purple},
            {ItemType.Pink, _spriteProvider.Pink},
        };
        
        private static readonly Dictionary<ItemType, SpriteId> _spriteIdByItemType = new()
        {
            {ItemType.Invalid, SpriteId.Invalid},
            {ItemType.Empty, SpriteId.Invalid},
            {ItemType.Red, SpriteId.Red},
            {ItemType.Blue, SpriteId.Blue},
            {ItemType.Green, SpriteId.Green},
            {ItemType.Yellow, SpriteId.Yellow},
            {ItemType.Purple, SpriteId.Purple},
            {ItemType.Pink, SpriteId.Pink},
        };
        
        public static Sprite GetSpriteByItemType(ItemType itemType)
        {
            return _spriteDataByItemType[itemType];
        }
        
        public static SpriteId GetSpriteIdByItemType(ItemType itemType)
        {
            return _spriteIdByItemType[itemType];
        }
    }
}