using System;
using System.Collections.Generic;
using System.Text;

namespace BulletJournal.Core.Models.Bullet
{
    public class Task : Bullet
    {
        public Status Status { get; set; }

        public bool IsActive { get; set; }
    }
}
