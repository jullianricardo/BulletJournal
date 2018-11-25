using System;
using System.Collections.Generic;
using System.Text;

namespace BulletJournal.Core.Models.Bullet
{
    public class Event : Bullet
    {
        public DateTime Date { get; set; }

        public TimeSpan Duration { get; set; }
    }
}
