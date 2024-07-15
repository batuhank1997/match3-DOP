using System;
using _Dev.Scripts.Enums;
using Newtonsoft.Json;

namespace _Dev.Scripts.Data
{
    [JsonConverter(typeof(ItemDataConverter))]
    public struct ItemData
    {
        public ItemType ItemType;
        public SpriteData SpriteData;

        public int XCoord;
        public int YCoord;
        
        public ItemData(ItemType itemType)
        {
            ItemType = itemType;
            var spriteId = SpriteContainer.GetSpriteIdByItemType(itemType);
            SpriteData = new SpriteData(new SpriteIdWrapper(spriteId));
            XCoord = 0;
            YCoord = 0;
        }
        
        [JsonConstructor]
        public ItemData(ItemType itemType, int xCoord, int yCoord)
        {
            ItemType = itemType;
            XCoord = xCoord;
            YCoord = yCoord;
            var spriteId = SpriteContainer.GetSpriteIdByItemType(itemType);
            SpriteData = new SpriteData(new SpriteIdWrapper(spriteId));
        }
    }
}
