using BulletJournal.Models.Domain;

namespace BulletJournal.Models
{
    public class Journal : Entity
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime DateCreated { get; set; }


        public Index? Index { get; set; }

        public List<Page>? Pages { get; set; }

    }
}
