using BulletJournal.Core.Domain;
using BulletJournal.Data.Model.Bullet;
using BulletJournal.Models.Domain;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BulletJournal.Data.Model.Collection
{
    public class LogEntity : Entity
    {
        [DefaultValue(1)]
        public int Order { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        #region Navigation Properties

        public string CollectionId { get; set; }

        public virtual CollectionEntity Collection { get; set; }

        public virtual ObservableCollection<BulletEntity> Bullets { get; set; } = new NullCollection<BulletEntity>();

        #endregion
    }
}
