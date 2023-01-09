using BulletJournal.Data.Model.Collection;
using BulletJournal.Models.Bullet;
using BulletJournal.Models.Domain;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulletJournal.Data.Model.Bullet
{
    public abstract class BulletEntity : Entity
    {
        public abstract BulletType Type { get; set; }

        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        public Signifier Signifier { get; set; }

        [DefaultValue(1)]
        public int Order { get; set; }


        #region Navigation Properties

        [StringLength(128)]
        [ForeignKey("Parent")]
        public string ParentId { get; set; }
        public virtual BulletEntity Parent { get; set; }


        public string LogId { get; set; }
        public virtual LogEntity Log { get; set; }

        #endregion

        public virtual void Patch(BulletEntity entity)
        {
            entity.Type = Type;
            entity.Description = Description;
            entity.DateCreated = DateCreated;
            entity.Signifier = Signifier;
            entity.Order = Order;
            entity.ParentId = ParentId;
            entity.LogId = LogId;
        }
    }
}
