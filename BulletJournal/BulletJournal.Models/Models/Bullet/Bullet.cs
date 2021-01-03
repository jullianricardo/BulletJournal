using System;
using System.Collections.Generic;
using System.Text;

namespace BulletJournal.Models.Bullet
{
    public abstract class Bullet
    {
        public Bullet Parent { get; set; }

        public long Id { get; set; }

        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        public Signifier Signifier { get; set; }
    }
}
