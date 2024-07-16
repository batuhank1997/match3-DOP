using System;
using _Dev.Scripts.Enums;
using Newtonsoft.Json;

namespace _Dev.Scripts.Data
{
    [JsonConverter(typeof(ItemDataConverter))]
    public readonly struct ItemData
    {
        [JsonProperty(nameof(ItemType))] public readonly ItemType ItemType;
        [JsonProperty(nameof(XCoord))] public readonly int XCoord;
        [JsonProperty(nameof(YCoord))] public readonly int YCoord;
        
        public ItemData(ItemType itemType)
        {
            ItemType = itemType;
            XCoord = 0;
            YCoord = 0;
        }
        
        [JsonConstructor]
        public ItemData(ItemType itemType, int xCoord, int yCoord)
        {
            ItemType = itemType;
            XCoord = xCoord;
            YCoord = yCoord;
        }
    }
}
