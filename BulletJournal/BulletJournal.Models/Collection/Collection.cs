using BulletJournal.Models.Domain;

namespace BulletJournal.Models.Collection
{
    public abstract class Collection : Entity
    {
        public abstract CollectionType Type { get; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Log Log { get; set; }

        public abstract Topic ToTopic();
    }
}
