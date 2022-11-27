using BulletJournal.Models.Bullet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Data.Model.Bullet
{
    public class BulletEntity
    {
        public BulletEntity? Parent { get; set; }

        public string? Description { get; set; }

        public DateTime? DateCreated { get; set; }

        public Signifier? Signifier { get; set; }
    }
}
