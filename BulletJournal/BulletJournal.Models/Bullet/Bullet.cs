using BulletJournal.Models.Domain;

namespace BulletJournal.Models.Bullet
{
    public abstract class Bullet : Entity
    {
        public abstract BulletType BulletType { get; }

        public Bullet Parent { get; set; }

        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        public Signifier Signifier { get; set; }
    }
}
