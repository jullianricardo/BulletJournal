using BulletJournal.Core.Common;
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

        public string PageId { get; set; }

        public virtual PageEntity Page { get; set; }

        public virtual ObservableCollection<LogEntity> Logs { get; set; }

        #endregion
    }
}
