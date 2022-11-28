using BulletJournal.Models.Calendar;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulletJournal.Models.Collection
{
    public class FutureLog : Collection
    {
        public Dictionary<Month, Collection> Months { get; set; } = new Dictionary<Month, Collection>();

        public int Year { get; set; }
    }
}
