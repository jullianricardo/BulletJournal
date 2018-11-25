using BulletJournal.Core.Models.Calendar;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulletJournal.Core.Models.Collection
{
    public class MonthlyLog : Collection
    {
        public Month Month { get; set; }

        public Calendar.Calendar Calendar { get; set; }
    }
}
