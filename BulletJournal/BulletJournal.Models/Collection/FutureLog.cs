using BulletJournal.Models.Calendar;
using BulletJournal.Models.Domain;

namespace BulletJournal.Models.Collection
{
    public class FutureLog : Collection
    {
        public override CollectionType Type => CollectionType.FutureLog;

        public Dictionary<Month, FutureLogMonth> Months { get; set; } = new Dictionary<Month, FutureLogMonth>();

        public int Year { get; set; }


        private SortedList<int, Log> _logs;
        public override SortedList<int, Log> Logs
        {
            get
            {
                if (_logs != null && _logs.Count > 0)
                    return _logs;

                var logs = new SortedList<int, Log>();
                foreach (var month in Months)
                {
                    logs.Add((int)month.Key, month.Value.Log);
                }

                _logs = logs;
                return _logs;
            }
            set { }
        }

        public override Topic ToTopic() => throw new NotImplementedException();

        public override int RetrieveCollectionSize()
        {

            if (Logs == null || Logs.Count == 0)
                return 0;

            int collectionSize = Logs.Sum(x => x.Value.GetLogSize());
            return collectionSize;
        }
    }

    public class FutureLogMonth : Entity
    {
        public Month Month { get; set; }

        public Log Log { get; set; }
    }
}
