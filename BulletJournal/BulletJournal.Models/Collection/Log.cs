using BulletJournal.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Models.Collection
{
    public class Log : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Bullet.Bullet> Bullets { get; set; } = new List<Bullet.Bullet>();

        public Log()
        {
            Bullets = new List<Bullet.Bullet>();
        }
    }
}
