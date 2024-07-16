using System;
using _Dev.Scripts.Enums;
using Newtonsoft.Json;

namespace _Dev.Scripts.Data
{
    public class ItemDataConverter : JsonConverter<ItemData>
    {
        public override void WriteJson(JsonWriter writer, ItemData itemData, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            
            serializer.Serialize(writer, itemData.XCoord);
            serializer.Serialize(writer, itemData.YCoord);
            serializer.Serialize(writer, itemData.ItemType);
            
            writer.WriteEndObject();
        }

        public override ItemData ReadJson(JsonReader reader, Type objectType, ItemData existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var xCoord = 0;
            var yCoord = 0;
            var itemType = ItemType.Invalid;
            
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = reader.Value?.ToString();
                    reader.Read();
                    
                    switch (propertyName)
                    {
                        case nameof(existingValue.XCoord):
                            xCoord = reader.Value != null ? Convert.ToInt32(reader.Value) : 0;
                            break;
                        case nameof(existingValue.YCoord):
                            yCoord = reader.Value != null ? Convert.ToInt32(reader.Value) : 0;
                            break;
                        case nameof(existingValue.ItemType):
                            itemType = (ItemType) Enum.Parse(typeof(ItemType), reader.Value.ToString());
                            break;
                    }
                }

                if (reader.TokenType == JsonToken.EndObject)
                    break;
            }

            return new ItemData(itemType, xCoord, yCoord);
        }
    }
}