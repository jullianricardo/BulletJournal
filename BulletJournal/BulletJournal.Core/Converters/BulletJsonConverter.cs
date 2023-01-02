using BulletJournal.Models.Bullet;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;

namespace BulletJournal.Core.Converters
{
    public class BulletSpecifiedConcreteClassConverter : DefaultContractResolver
    {
        protected override JsonConverter ResolveContractConverter(Type objectType)
        {
            if (typeof(Bullet).IsAssignableFrom(objectType) && !objectType.IsAbstract)
                return null; // pretend TableSortRuleConvert is not specified (thus avoiding a stack overflow)
            return base.ResolveContractConverter(objectType);
        }
    }

    public class BulletJsonConverter : JsonConverter
    {
        static JsonSerializerSettings SpecifiedSubclassConversion = new JsonSerializerSettings() { ContractResolver = new BulletSpecifiedConcreteClassConverter(), NullValueHandling = NullValueHandling.Ignore };

        public override bool CanConvert(Type objectType)
        {
            bool canConvert = objectType == typeof(Bullet);
            return canConvert;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jo = JObject.Load(reader);
            int type = jo.Property("bulletType", StringComparison.OrdinalIgnoreCase).Value.Value<int>();
            var bulletType = (BulletType)type;

            Bullet bullet = bulletType switch
            {
                BulletType.Task => new Task(),
                BulletType.Note => new Note(),
                BulletType.Event => new Event(),
                _ => throw new NotImplementedException()
            };

            serializer.Populate(jo.CreateReader(), bullet);
            return bullet;
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException(); // won't be called because CanWrite returns false
        }
    }
}
