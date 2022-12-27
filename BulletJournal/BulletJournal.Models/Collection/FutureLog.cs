using BulletJournal.Models.Calendar;
using BulletJournal.Models.Domain;

namespace BulletJournal.Models.Collection
{
    public class FutureLog : Collection
    {
        public override CollectionType Type => CollectionType.FutureLog;

        public Dictionary<Month, FutureLogMonth> Months { get; set; } = new Dictionary<Month, FutureLogMonth>();

        public int Year { get; set; }

        public override Topic ToTopic() => throw new NotImplementedException();
    }

    public class FutureLogMonth : Entity
    {
        public Month Month { get; set; }

        public Log Log { get; set; }
    }
}
