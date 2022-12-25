using BulletJournal.Models.Calendar;
using BulletJournal.Models.Domain;

namespace BulletJournal.Models.Collection
{
    public class FutureLog : Collection
    {
        public List<FutureLogMonth> Months { get; set; } = new List<FutureLogMonth>();

        public int Year { get; set; }
    }

    public class FutureLogMonth : Entity
    {
        public Month Month { get; set; }

        public Collection Collection { get; set; }
    }
}
