using System;
using Newtonsoft.Json;

namespace _Dev.Scripts.Data
{
    public class LevelDataConverter : JsonConverter<LevelData>
    {
            public override void WriteJson(JsonWriter writer, LevelData levelData, JsonSerializer serializer)
            {
                writer.WriteStartObject();
                writer.WritePropertyName("X");
                writer.WriteValue(levelData.X);
                writer.WritePropertyName("Y");
                writer.WriteValue(levelData.Y);
                writer.WritePropertyName("LevelItems");

                foreach (var itemData in levelData.LevelItems)
                    writer.WriteValue(itemData);
                
                writer.WriteEndObject();
            }

            public override LevelData ReadJson(JsonReader reader, Type objectType, LevelData existingValue, bool hasExistingValue,
                JsonSerializer serializer)
            {
                var x = 0;
                var y = 0;
                var levelItems = new LevelData();

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
                                reader.Read();
                                while (reader.TokenType != JsonToken.EndArray)
                                {
                                    var itemData = serializer.Deserialize<ItemData>(reader);
                                    levelItems.LevelItems.Add(itemData);
                                }
                                break;
                        }
                    }

                    if (reader.TokenType == JsonToken.EndObject)
                        break;
                }

                levelItems.X = x;
                levelItems.Y = y;
                return levelItems;
            }
    }
}