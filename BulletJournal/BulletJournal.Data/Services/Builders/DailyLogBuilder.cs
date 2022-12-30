using BulletJournal.Core.Services.Builders;
using BulletJournal.Models.Bullet;
using BulletJournal.Models.Calendar;
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

            var log = new Models.Log
            {
                Order = 1,
                Name = "Log Padrão",
                Description = "Log Padrão",
            };

            for (int j = 0; j < 10; j++)
            {
                log.Bullets.Add((j + 1), new Note { Description = $"Test Bullet n. {j + 1}" });
            }

            return dailyLog;
        }

        public SortedList<int, DailyLog> BuildDailyLogsForMonth(Month month, int year)
        {
            var dailyLogs = new SortedList<int, DailyLog>();

            var dates = GetDates((int)month, year);
            int order = 1;

            foreach (var date in dates)
            {
                if (date < DateTime.Today)
                {
                    continue;
                }

                var dailyLog = new DailyLog
                {
                    Name = $"Log Diário - {date.ToShortDateString()}",
                    Description = "Log Diário",
                    CurrentDay = date,
                    Order = order,
                };

                var log = new Models.Log
                {
                    Order = 1,
                    Name = "Log Padrão",
                    Description = "Log Padrão",
                };

                for (int j = 0; j < 10; j++)
                {
                    log.Bullets.Add((j + 1), new Note { Description = $"Test Bullet n. {j + 1}" });
                }

                dailyLog.Logs = new SortedList<int, Models.Log>
                {
                    [1] = log
                };

                dailyLogs.Add(order, dailyLog);
                order++;
            }

            return dailyLogs;
        }

        private static List<DateTime> GetDates(int month, int year)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(year, month))  // Days: 1, 2 ... 31 etc.
                             .Select(day => new DateTime(year, month, day)) // Map each day to a date
                             .ToList(); // Load dates into a list
        }
    }
}
