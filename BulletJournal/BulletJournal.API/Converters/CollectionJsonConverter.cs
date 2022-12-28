using BulletJournal.Models.Collection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.API.Converters
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
        static JsonSerializerSettings SpecifiedSubclassConversion = new JsonSerializerSettings() { ContractResolver = new CollectionSpecifiedConcreteClassConverter(), TypeNameHandling = TypeNameHandling.All };

        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Collection));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            int type = jo["type"].Value<int>();
            var collectionType = (CollectionType)type;

            //switch (collectionType)
            //{
            //    case CollectionType.FutureLog:
            //        return JsonConvert.DeserializeObject<FutureLog>(jo.ToString(), SpecifiedSubclassConversion);

            //    case CollectionType.MonthlyLog:
            //        return JsonConvert.DeserializeObject<MonthlyLog>(jo.ToString(), SpecifiedSubclassConversion);

            //    case CollectionType.DailyLog:
            //        return JsonConvert.DeserializeObject<DailyLog>(jo.ToString(), SpecifiedSubclassConversion);

            //    case CollectionType.List:
            //        return JsonConvert.DeserializeObject<ListCollection>(jo.ToString(), SpecifiedSubclassConversion);

            //    case CollectionType.UserDefined:
            //        return JsonConvert.DeserializeObject<UserDefinedLog>(jo.ToString(), SpecifiedSubclassConversion);

            //    default:
            //        throw new Exception();
            //}

            Collection collection;

            switch (collectionType)
            {
                case CollectionType.FutureLog:
                    collection = new FutureLog();
                    break;

                case CollectionType.MonthlyLog:
                    collection = new MonthlyLog();
                    break;

                case CollectionType.DailyLog:
                    collection = new DailyLog();
                    break;

                case CollectionType.List:
                    collection = new ListCollection();
                    break;

                case CollectionType.UserDefined:
                    collection = new UserDefinedLog();
                    break;

                default:
                    throw new Exception();
            }

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
