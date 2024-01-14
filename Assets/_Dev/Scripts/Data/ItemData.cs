namespace _Dev.Scripts.Data
{
    public readonly struct ItemData
    {
        public readonly ItemType ItemType;
        public readonly SpriteData SpriteData;
        
        public ItemData(ItemType itemType, SpriteData sprite)
        {
            ItemType = itemType;
            SpriteData = new SpriteData(sprite.Sprite);
        }
    }
    
    public enum ItemType : byte
    {
        Invalid = 0,
        Red = 1,
        Blue = 2,
        Green = 3,
        Yellow = 4,
        Purple = 5,
        Pink = 6,
    }
}
