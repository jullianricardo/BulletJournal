using BulletJournal.Models.Calendar;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulletJournal.Models.Collection
{
    public class MonthlyLog : Collection
    {
        public Month Month { get; set; }

        public Calendar.Calendar Calendar { get; set; }
    }
}
