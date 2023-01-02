using BulletJournal.Models.Domain;

namespace BulletJournal.Data.Model.Collection
{
    public class CollectionPageEntity : Entity
    {
        public string PageId { get; set; }

        public PageEntity Page { get; set; }


        public string CollectionId { get; set; }

        public CollectionEntity Collection { get; set; }

    }
}
