using BulletJournal.Models.Calendar;
using BulletJournal.Models.Collection;
using System.Collections;
using System.Collections.Generic;

namespace BulletJournal.Core.Services.Builders
{
    public interface IDailyLogBuilder
    {
        DailyLog BuildDefaultDailyLog();

        SortedList<int, DailyLog> BuildDailyLogsForMonth(Month month, int year);
    }
}
