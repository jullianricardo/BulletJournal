using BulletJournal.Core.Services.Builders;
using BulletJournal.Models.Calendar;
using BulletJournal.Models.Collection;

namespace BulletJournal.Data.Services.Builders
{
    public class MonthlyLogBuilder : IMonthlyLogBuilder
    {
        public MonthlyLog BuildDefaultMonthlyLog()
        {
            var today = DateTime.Today;

            var monthlyLog = new MonthlyLog
            {
                Name = $"Log Mensal - {today.ToShortDateString()}",
                Description = "Log Mensal",
                Month = (Month)today.Month
            };

            return monthlyLog;
        }
    }
}
