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
            };

            for (int j = 0; j < 10; j++)
            {
                BulletType bulletType = (BulletType)Random.Shared.Next(0, 3);
                string description = $"Test Bullet n. {j + 1}";
                Bullet bullet;

                if (bulletType == BulletType.Note)
                    bullet = new Note { Order = j + 1, Description = description };
                else if (bulletType == BulletType.Task)
                    bullet = new Models.Bullet.Task { Order = j + 1, Description = description };
                else
                    bullet = new Event { Order = j + 1, Description = description };


                log.Bullets.Add((j + 1), bullet);
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
                //if (date < DateTime.Today.AddDays(-2))
                //{
                //    continue;
                //}

                var dailyLog = new DailyLog
                {
                    Name = $"Log Diário - {date.ToShortDateString()}",
                    Description = "Log Diário",
                    CurrentDay = date,
                    Order = order,
                };

                var log = new Models.Log
                {
                    Order = 1
                };

                int size = Random.Shared.Next(1, 8);

                for (int j = 1; j <= size; j++)
                {
                    BulletType bulletType = (BulletType)Random.Shared.Next(0, 3);
                    string description = $"Test Bullet n. {j + 1}";
                    Bullet bullet;

                    if (bulletType == BulletType.Note)
                        bullet = new Note { Order = j, Description = description };
                    else if (bulletType == BulletType.Task)
                        bullet = new Models.Bullet.Task { Order = j, Description = description };
                    else
                        bullet = new Event { Order = j, Description = description };

                    log.Bullets.Add(j, bullet);
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
