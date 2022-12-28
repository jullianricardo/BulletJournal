using BulletJournal.Models.Domain;

namespace BulletJournal.Models
{
    public class Page : Entity
    {
        public Page()
        {
            Collections = new SortedList<int, Collection.Collection>();
        }

        public string Title { get; set; }

        public int Number { get; set; }

        public SortedList<int, Collection.Collection> Collections { get; set; }


        public int CurrentSize
        {
            get
            {
                if (Collections == null || Collections.Count == 0)
                    return 0;

                int size = Collections.Values.Sum(x => x.RetrieveCollectionSize());
                return size;
            }
        }
    }
}
