using BulletJournal.Core.Common;
using BulletJournal.Core.Domain;
using BulletJournal.Data.Model.Bullet;
using BulletJournal.Models.Domain;
using System.Collections.ObjectModel;

namespace BulletJournal.Data.Model.Collection
{
    public class CollectionEntity : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        #region Navigation Properties

        public string PageId { get; set; }

        public virtual PageEntity Page { get; set; }

        public virtual ObservableCollection<BulletEntity> Bullets { get; set; } = new NullCollection<BulletEntity>();

        #endregion

        public virtual Models.Collection.Collection ToModel(Models.Collection.Collection collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            collection.Id = Id;
            collection.Name = Name;
            collection.Description = Description;

            return collection;
        }

        public virtual CollectionEntity FromModel(Models.Collection.Collection collection, PrimaryKeyResolvingMap primaryKeyResolvingMap)
        {
            primaryKeyResolvingMap.AddPair(collection, this);

            Id = collection.Id;
            Name = collection.Name;
            Description = collection.Description;

            return this;
        }
    }
}
