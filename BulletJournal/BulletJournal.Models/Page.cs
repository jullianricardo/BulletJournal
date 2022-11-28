using BulletJournal.Models.Domain;

namespace BulletJournal.Models
{
    public class Page : Entity
    {
        public int Number { get; set; }

        public List<Collection.Collection>? Collections { get; set; }
    }
}
