using _Dev.Scripts.Enums;
using _Dev.Scripts.Interfaces;
using _Dev.Scripts.Skills;
using Newtonsoft.Json;

namespace _Dev.Scripts.Data
{
    [JsonConverter(typeof(ItemDataConverter))]
    public readonly struct ItemData
    {
        [JsonProperty(nameof(ItemType))] public readonly ItemType ItemType;
        [JsonProperty(nameof(XCoord))] public readonly int XCoord;
        [JsonProperty(nameof(YCoord))] public readonly int YCoord;
        
        public readonly IItemSkill Skill;
        
        public ItemData(ItemType itemType)
        {
            ItemType = itemType;
            Skill = new NoSkill();
            XCoord = 0;
            YCoord = 0;
        }
        
        public ItemData(ItemType itemType, IItemSkill itemSkill, int xCoord, int yCoord)
        {
            ItemType = itemType;
            Skill = itemSkill;
            XCoord = xCoord;
            YCoord = yCoord;
        }
        
        [JsonConstructor]
        public ItemData(ItemType itemType, int xCoord, int yCoord)
        {
            ItemType = itemType;
            Skill = new NoSkill();
            XCoord = xCoord;
            YCoord = yCoord;
        }
    }
}
