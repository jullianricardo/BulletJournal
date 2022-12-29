using BulletJournal.Models.Domain;
using Newtonsoft.Json;
using System.ComponentModel;

namespace BulletJournal.Models.Collection
{

    public abstract class Collection : Entity
    {
        public Collection()
        {
            Logs = new SortedList<int, Log>();
        }

        public abstract CollectionType Type { get; }

        public string Name { get; set; }

        public string Description { get; set; }

        [DefaultValue(1)]
        public int Order { get; set; }

        public virtual SortedList<int, Log> Logs { get; set; }

        public virtual int RetrieveCollectionSize()
        {
            if (Logs == null)
                return 0;

            int collectionSize = Logs.Sum(x => x.Value.GetLogSize());
            return collectionSize;
        }



        public abstract Topic ToTopic();
    }
}
