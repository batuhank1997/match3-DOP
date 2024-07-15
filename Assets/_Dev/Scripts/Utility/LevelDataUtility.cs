using System.Collections.Generic;
using _Dev.Providers;
using _Dev.Scripts.Enums;

namespace _Dev.Scripts.Utility
{
    public static class LevelDataUtility
    {
        private static readonly Dictionary<string, ItemType> _itemTypeBySpriteName = new Dictionary<string, ItemType>()
        {
            {ServiceLocator.Instance.Get<SpriteProvider>().Blue.name, ItemType.Blue},
            {ServiceLocator.Instance.Get<SpriteProvider>().Green.name, ItemType.Green},
            {ServiceLocator.Instance.Get<SpriteProvider>().Pink.name, ItemType.Pink},
            {ServiceLocator.Instance.Get<SpriteProvider>().Purple.name, ItemType.Purple},
            {ServiceLocator.Instance.Get<SpriteProvider>().Red.name, ItemType.Red},
            {ServiceLocator.Instance.Get<SpriteProvider>().Yellow.name, ItemType.Yellow},
        };
        
        public static ItemType GetItemTypeBySpriteName(string spriteName)
        {
            return _itemTypeBySpriteName.GetValueOrDefault(spriteName, ItemType.Invalid);
        }
    }
}