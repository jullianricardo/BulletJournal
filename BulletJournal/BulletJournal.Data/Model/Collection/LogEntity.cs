using BulletJournal.Core.Common;
using BulletJournal.Core.Domain;
using BulletJournal.Data.Model.Bullet;
using BulletJournal.Data.Model.Calendar;
using BulletJournal.Models.Bullet;
using BulletJournal.Models.Calendar;
using BulletJournal.Models.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Data.Model.Collection
{
    public class LogEntity : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        #region Navigation Properties

        public string CollectionId { get; set; }

        public virtual CollectionEntity Collection { get; set; }

        public virtual ObservableCollection<BulletEntity> Bullets { get; set; } = new NullCollection<BulletEntity>();

        #endregion

        public virtual Models.Collection.Log ToModel(Models.Collection.Log log)
        {
            if (log == null)
                throw new ArgumentNullException(nameof(log));

            log.Id = Id;
            log.Name = Name;
            log.Description = Description;
            log.Bullets = Bullets.Select(x => x.ToModel(AbstractTypeFactory<Models.Bullet.Bullet>.TryCreateInstance())).ToList();

            return log;
        }

        public virtual LogEntity FromModel(Models.Collection.Log log, PrimaryKeyResolvingMap primaryKeyResolvingMap)
        {
            primaryKeyResolvingMap.AddPair(log, this);

            Id = log.Id;
            Name = log.Name;
            Description = log.Description;
            Bullets = new ObservableCollection<BulletEntity>(log.Bullets.Select(x => AbstractTypeFactory<BulletEntity>.TryCreateInstance().FromModel(x, primaryKeyResolvingMap)));

            return this;
        }
    }
}
