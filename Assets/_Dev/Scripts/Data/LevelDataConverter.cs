using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace _Dev.Scripts.Data
{
    public class LevelDataConverter : JsonConverter<LevelData>
    {
            public override void WriteJson(JsonWriter writer, LevelData levelData, JsonSerializer serializer)
            {
                writer.WriteStartObject();
                
                serializer.Serialize(writer, levelData.X);
                serializer.Serialize(writer, levelData.Y);
                serializer.Serialize(writer, levelData.LevelItems);

                writer.WriteEndObject();
            }

            public override LevelData ReadJson(JsonReader reader, Type objectType, LevelData existingValue, bool hasExistingValue,
                JsonSerializer serializer)
            {
                var x = 0;
                var y = 0;
                var levelItems = new List<ItemData>();
                
                var levelData = new LevelData();

                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.PropertyName)
                    {
                        var propertyName = reader.Value.ToString();
                        reader.Read();
                        switch (propertyName)
                        {
                            case "X":
                                x = int.Parse(reader.Value.ToString());
                                break;
                            case "Y":
                                y = int.Parse(reader.Value.ToString());
                                break;
                            case "LevelItems":
                                levelItems = serializer.Deserialize<List<ItemData>>(reader);
                                break;
                        }
                    }

                    if (reader.TokenType == JsonToken.EndObject)
                        break;
                }

                levelData.X = x;
                levelData.Y = y;
                levelData.LevelItems = levelItems;
                return levelData;
            }
    }
}