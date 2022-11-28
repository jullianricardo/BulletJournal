using BulletJournal.Models.Domain;

namespace BulletJournal.Models.Calendar
{
    public class Calendar : Entity
    {
        public List<Day> Days { get; set; } = new List<Day>();
    }
}
