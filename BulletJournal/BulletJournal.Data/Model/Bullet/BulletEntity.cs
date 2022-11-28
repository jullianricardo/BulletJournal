using BulletJournal.Core.Common;
using BulletJournal.Core.Domain;
using BulletJournal.Models.Bullet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Data.Model.Bullet
{
    public class BulletEntity : Entity
    {
        public virtual BulletEntity? Parent { get; set; }

        public string? Description { get; set; }

        public DateTime DateCreated { get; set; }

        public Signifier Signifier { get; set; }


        public virtual Models.Bullet.Bullet ToModel(Models.Bullet.Bullet? bullet)
        {
            if (bullet == null) throw new ArgumentNullException(nameof(bullet));

            bullet.Description = Description;
            bullet.DateCreated = DateCreated;
            bullet.Signifier = Signifier;

            return bullet;
        }

        public virtual BulletEntity FromModel(Models.Bullet.Bullet? bullet, PrimaryKeyResolvingMap primaryKeyResolvingMap)
        {
            if (bullet == null) throw new ArgumentNullException(nameof(bullet));

            primaryKeyResolvingMap.AddPair(bullet, this);

            Description = bullet.Description;
            DateCreated = bullet.DateCreated;
            Signifier = bullet.Signifier;


            return this;
        }
    }
}
