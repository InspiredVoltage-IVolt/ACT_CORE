using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace ACT.Core.Encoding.JSON
{
    public static class DefaultConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            return -1;
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            try
            {
                var value = (long)untypedValue;
                serializer.Serialize(writer, value.ToString());
                return;
            }
            catch
            {
                var value = (long)-1;
                serializer.Serialize(writer, value.ToString());
                return;
            }
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
