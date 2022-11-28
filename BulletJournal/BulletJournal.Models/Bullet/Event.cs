using System;
using System.Collections.Generic;
using System.Text;

namespace BulletJournal.Models.Bullet
{
    public class Event : Bullet
    {
        public override BulletType BulletType => BulletType.Event;

        public DateTime Date { get; set; }

        public TimeSpan Duration { get; set; }
    }
}
