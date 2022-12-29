using BulletJournal.Core.Services.Builders;
using BulletJournal.Models.Bullet;
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

            for (int j = 0; j < 30; j++)
            {
                log.Bullets.Add((j + 1), new Note { Description = $"Test Bullet n. {j + 1}" });
            }

            return dailyLog;
        }
    }
}
