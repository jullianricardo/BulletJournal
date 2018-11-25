using BulletJournal.Core.Models.Calendar;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulletJournal.Core.Models.Collection
{
    public class FutureLog : Collection
    {
        public Dictionary<Month, Collection> Months { get; set; }

        public int Year { get; set; }
    }
}
