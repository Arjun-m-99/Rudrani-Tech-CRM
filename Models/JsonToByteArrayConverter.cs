using System.Text.Json;
using System.Text.Json.Serialization;

namespace Rudrani_Tech_CRM.Models
{
    internal class JsonToByteArrayConverter : JsonConverter<byte[]?>
    {
        //// Converts base64 encoded string to byte[].
        //public override byte[]? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        //{
        //    if (!reader.TryGetBytesFromBase64(out byte[]? result) || result == default)
        //    {
        //        throw new Exception("Add your fancy exception message here...");
        //    }
        //    return result;
        //}

        //// Converts byte[] to base64 encoded string.
        //public override void Write(Utf8JsonWriter writer, byte[]? value, JsonSerializerOptions options)
        //{
        //    writer.WriteBase64StringValue(value);
        //}

        public override byte[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            short[] sByteArray = JsonSerializer.Deserialize<short[]>(ref reader);
            byte[] value = new byte[sByteArray.Length];
            for (int i = 0; i < sByteArray.Length; i++)
            {
                value[i] = (byte)sByteArray[i];
            }

            return value;
        }

        public override void Write(Utf8JsonWriter writer, byte[] value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();

            foreach (var val in value)
            {
                writer.WriteNumberValue(val);
            }

            writer.WriteEndArray();
        }
    }
}