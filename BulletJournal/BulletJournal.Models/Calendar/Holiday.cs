using BulletJournal.Models.Domain;

namespace BulletJournal.Models.Calendar
{
    public class Holiday : Entity
    {
        public DateTime Date { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
