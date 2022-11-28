using BulletJournal.Core.Common;
using BulletJournal.Data.Model.Collection;
using BulletJournal.Models.Bullet;
using BulletJournal.Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulletJournal.Data.Model.Bullet
{
    public class BulletEntity : Entity
    {
        public string? Description { get; set; }

        public DateTime DateCreated { get; set; }

        public Signifier Signifier { get; set; }


        #region Navigation Properties

        [StringLength(128)]
        [ForeignKey("Parent")]
        public string? ParentId { get; set; }
        public virtual BulletEntity? Parent { get; set; }


        public string? CollectionId { get; set; }
        public virtual CollectionEntity? Collection { get; set; }

        #endregion


        public virtual Models.Bullet.Bullet ToModel(Models.Bullet.Bullet? bullet)
        {
            if (bullet == null)
                throw new ArgumentNullException(nameof(bullet));

            bullet.Description = Description;
            bullet.DateCreated = DateCreated;
            bullet.Signifier = Signifier;

            return bullet;
        }

        public virtual BulletEntity FromModel(Models.Bullet.Bullet? bullet, PrimaryKeyResolvingMap primaryKeyResolvingMap)
        {
            if (bullet == null)
                throw new ArgumentNullException(nameof(bullet));

            primaryKeyResolvingMap.AddPair(bullet, this);

            Description = bullet.Description;
            DateCreated = bullet.DateCreated;
            Signifier = bullet.Signifier;


            return this;
        }
    }
}
