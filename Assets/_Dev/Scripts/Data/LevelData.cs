using System.Collections.Generic;
using Newtonsoft.Json;

namespace _Dev.Scripts.Data
{
    [JsonConverter(typeof(LevelDataConverter))]
    public class LevelData
    {
        [JsonProperty("X")] public int X;
        [JsonProperty("Y")] public int Y;
        [JsonProperty("LevelItems")] public List<ItemData> LevelItems;
    }
}