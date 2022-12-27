﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BulletJournal.Models.Collection
{
    public class DailyLog : Collection
    {
        public override CollectionType Type => CollectionType.DailyLog;

        public DateTime CurrentDay { get; set; }

        public override Topic ToTopic() => throw new NotImplementedException();
    }
}
