using BulletJournal.Models.Bullet;
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
        static JsonSerializerSettings SpecifiedSubclassConversion = new JsonSerializerSettings() { ContractResolver = new BulletSpecifiedConcreteClassConverter() };

        public override bool CanConvert(Type objectType)
        {
            bool canConvert = objectType == typeof(Bullet);
            return canConvert;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            int type = jo["bulletType"].Value<int>();
            var bulletType = (BulletType)type;

            switch (bulletType)
            {
                case BulletType.Task:
                    return JsonConvert.DeserializeObject<Models.Bullet.Task>(jo.ToString(), SpecifiedSubclassConversion);

                case BulletType.Note:
                    return JsonConvert.DeserializeObject<Note>(jo.ToString(), SpecifiedSubclassConversion);

                case BulletType.Event:
                    return JsonConvert.DeserializeObject<Event>(jo.ToString(), SpecifiedSubclassConversion);

                default:
                    throw new Exception();
            }
            throw new NotImplementedException();
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
