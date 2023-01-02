using BulletJournal.Core.Domain;
using BulletJournal.Data.Model.Collection;
using BulletJournal.Models.Domain;
using System.Collections.ObjectModel;

namespace BulletJournal.Data.Model
{
    public class PageEntity : Entity
    {
        public int Number { get; set; }
        public string Title { get; set; }


        #region NavigationProperties

        public string JournalId { get; set; }

        public virtual JournalEntity Journal { get; set; }

        public virtual ObservableCollection<CollectionPageEntity> CollectionPages { get; set; } = new NullCollection<CollectionPageEntity>();

        #endregion
    }
}
