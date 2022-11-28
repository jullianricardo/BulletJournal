using BulletJournal.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Models.Collection
{
    public class Collection : Entity
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public List<Bullet.Bullet> Bullets { get; set; }
    }
}
