using BulletJournal.Core.Common;
using BulletJournal.Core.Domain;
using BulletJournal.Data.Model.Bullet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Data.Model.Collection
{
    public class CollectionEntity : Entity
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public virtual ObservableCollection<BulletEntity> Bullets { get; set; } = new NullCollection<BulletEntity>();


        public virtual Models.Collection.Collection ToModel(Models.Collection.Collection collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            collection.Name = Name;
            collection.Description = Description;

            return collection;
        }

        public virtual CollectionEntity FromModel(Models.Collection.Collection collection, PrimaryKeyResolvingMap primaryKeyResolvingMap)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            primaryKeyResolvingMap.AddPair(collection, this);

            Name = collection.Name;
            Description = collection.Description;

            return this;
        }
    }
}
