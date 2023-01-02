using BulletJournal.Models.Collection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;

namespace BulletJournal.Core.Converters
{
    public class CollectionSpecifiedConcreteClassConverter : DefaultContractResolver
    {
        protected override JsonConverter ResolveContractConverter(Type objectType)
        {
            if (typeof(Collection).IsAssignableFrom(objectType) && !objectType.IsAbstract)
                return null; // pretend TableSortRuleConvert is not specified (thus avoiding a stack overflow)
            return base.ResolveContractConverter(objectType);
        }
    }

    public class CollectionJsonConverter : JsonConverter
    {
        static JsonSerializerSettings SpecifiedSubclassConversion = new JsonSerializerSettings()
        {
            ContractResolver = new CollectionSpecifiedConcreteClassConverter(),
        };

        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Collection));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jo = JObject.Load(reader);
            int type = jo.Property("type", StringComparison.OrdinalIgnoreCase).Value.Value<int>();
            var collectionType = (CollectionType)type;

            Collection collection = collectionType switch
            {
                CollectionType.FutureLog => new FutureLog(),
                CollectionType.MonthlyLog => new MonthlyLog(),
                CollectionType.DailyLog => new DailyLog(),
                CollectionType.List => new ListCollection(),
                CollectionType.UserDefined => new UserDefinedLog(),
                _ => throw new Exception(),
            };

            serializer.Populate(jo.CreateReader(), collection);
            return collection;
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
