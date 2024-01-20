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
    
    public enum ItemType
    {
        Invalid = -1,
        Empty = 0,
        Red = 1,
        Blue = 2,
        Green = 3,
        Yellow = 4,
        Purple = 5,
        Pink = 6,
    }
}
