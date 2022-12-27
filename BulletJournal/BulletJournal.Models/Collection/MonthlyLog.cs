using BulletJournal.Models.Calendar;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulletJournal.Models.Collection
{
    public class MonthlyLog : Collection
    {
        public override CollectionType Type => CollectionType.MonthlyLog;

        public Month Month { get; set; }

        public Calendar.Calendar Calendar { get; set; }

        public override Topic ToTopic() => throw new NotImplementedException();
    }
}
