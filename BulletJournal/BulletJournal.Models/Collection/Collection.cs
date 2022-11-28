using BulletJournal.Models.Domain;

namespace BulletJournal.Models.Collection
{
    public class Collection : Entity
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public List<Bullet.Bullet> Bullets { get; set; } = new List<Bullet.Bullet>();
    }
}
