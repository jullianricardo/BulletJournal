using BulletJournal.Core.Services.Builders;
using BulletJournal.Models.Collection;

namespace BulletJournal.Data.Services.Builders
{
    public class DailyLogBuilder : IDailyLogBuilder
    {
        public DailyLog BuildDefaultDailyLog()
        {
            var today = DateTime.Today;

            var dailyLog = new DailyLog
            {
                Name = $"Log Diário - {today.ToShortDateString()}",
                Description = "Log Diário",
                CurrentDay = today,
            };

            return dailyLog;
        }
    }
}
