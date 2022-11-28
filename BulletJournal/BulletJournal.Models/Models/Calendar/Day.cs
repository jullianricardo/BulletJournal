using BulletJournal.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulletJournal.Models.Calendar
{
    public class Day : Entity
    {
        public int Number { get; set; }

        public WeekDay WeekDay { get; set; }

        public bool IsHoliday { get; set; }

        public Holiday Holiday { get; set; }

        public Collection.Collection Entries { get; set; }
    }
}
