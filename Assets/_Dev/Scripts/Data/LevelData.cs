using System.Collections.Generic;
using Newtonsoft.Json;

namespace _Dev.Scripts.Data
{
    [JsonConverter(typeof(LevelDataConverter))]
    public class LevelData
    {
        public int X;
        public int Y;
        public List<ItemData> LevelItems;
    }
}