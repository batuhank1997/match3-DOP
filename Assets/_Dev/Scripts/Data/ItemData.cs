using _Dev.Scripts.Enums;

namespace _Dev.Scripts.Data
{
    public readonly struct ItemData
    {
        public readonly ItemType ItemType;
        public readonly SpriteData SpriteData;
        
        public ItemData(ItemType itemType)
        {
            ItemType = itemType;
            var spriteId = SpriteContainer.GetSpriteIdByItemType(itemType);
            SpriteData = new SpriteData(new SpriteIdWrapper(spriteId));
        }
    }
}
