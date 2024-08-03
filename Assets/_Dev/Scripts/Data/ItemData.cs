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
        [JsonProperty(nameof(SkillItemType))] public readonly ItemType SkillItemType;
        [JsonProperty(nameof(XCoord))] public readonly int XCoord;
        [JsonProperty(nameof(YCoord))] public readonly int YCoord;
        
        public readonly IItemSkill Skill;
        
        public ItemData(ItemType itemType)
        {
            ItemType = itemType;
            SkillItemType = itemType;
            Skill = new NoSkill();
            XCoord = 0;
            YCoord = 0;
        }
        
        public ItemData(ItemType itemType, ItemType skillItemType, IItemSkill itemSkill, int xCoord, int yCoord)
        {
            ItemType = itemType;
            SkillItemType = skillItemType;
            Skill = itemSkill;
            XCoord = xCoord;
            YCoord = yCoord;
        }
        
        [JsonConstructor]
        public ItemData(ItemType itemType, int xCoord, int yCoord)
        {
            ItemType = itemType;
            SkillItemType = itemType;
            Skill = new NoSkill();
            XCoord = xCoord;
            YCoord = yCoord;
        }
    }
}
