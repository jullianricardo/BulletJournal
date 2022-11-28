using System;
using System.Collections.Generic;
using System.Text;

namespace BulletJournal.Models.Bullet
{
    public class Task : Bullet
    {
        public override BulletType BulletType => BulletType.Task;

        public Status Status { get; set; }

        public bool IsActive { get; set; }
    }
}
