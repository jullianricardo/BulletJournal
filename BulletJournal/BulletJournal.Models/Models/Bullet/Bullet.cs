using BulletJournal.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulletJournal.Models.Bullet
{
    public abstract class Bullet : Entity
    {
        public Bullet? Parent { get; set; }

        public string? Description { get; set; }

        public DateTime DateCreated { get; set; }

        public Signifier Signifier { get; set; }
    }
}
