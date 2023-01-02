using BulletJournal.Core.Domain;
using BulletJournal.Models.Collection;
using BulletJournal.Models.Domain;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BulletJournal.Data.Model.Collection
{
    public abstract class CollectionEntity : Entity
    {
        public abstract CollectionType Type { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [DefaultValue(1)]
        public int Order { get; set; }


        #region Navigation Properties

        public string JournalId { get; set; }

        public virtual JournalEntity Journal { get; set; }

        public virtual ObservableCollection<CollectionPageEntity> CollectionPages { get; set; } = new NullCollection<CollectionPageEntity>();

        public virtual ObservableCollection<LogEntity> Logs { get; set; } = new NullCollection<LogEntity>();

        #endregion
    }
}
