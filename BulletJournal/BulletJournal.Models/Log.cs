using BulletJournal.Models.Domain;
using System.ComponentModel;

namespace BulletJournal.Models
{
    public class Log : Entity
    {
        [DefaultValue(1)]
        public int Order { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public SortedList<int, Bullet.Bullet> Bullets { get; set; } = new SortedList<int, Bullet.Bullet>();

        public Log()
        {
            Bullets = new SortedList<int, Bullet.Bullet>();
        }

        public int GetLogSize()
        {
            return Bullets.Count;
        }
    }
}
