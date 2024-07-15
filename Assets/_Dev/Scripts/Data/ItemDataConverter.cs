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
            writer.WritePropertyName("XCoord");
            writer.WriteValue(itemData.XCoord);
            writer.WritePropertyName("YCoord");
            writer.WriteValue(itemData.YCoord);
            writer.WritePropertyName("ItemType");
            writer.WriteValue(itemData.ItemType.ToString());
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
                    var propertyName = reader.Value.ToString();
                    reader.Read();
                    switch (propertyName)
                    {
                        case "XCoord":
                            xCoord = int.Parse(reader.Value.ToString());
                            break;
                        case "YCoord":
                            yCoord = int.Parse(reader.Value.ToString());
                            break;
                        case "ItemType":
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