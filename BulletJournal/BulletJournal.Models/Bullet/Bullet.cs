using BulletJournal.Models.Domain;
using System.ComponentModel;

namespace BulletJournal.Models.Bullet
{
    public abstract class Bullet : Entity
    {
        public abstract BulletType BulletType { get; }

        public Bullet Parent { get; set; }

        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        public Signifier Signifier { get; set; }

        [DefaultValue(1)]
        public int Order { get; set; }
    }
}
