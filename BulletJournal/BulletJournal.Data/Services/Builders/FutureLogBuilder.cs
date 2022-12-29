using BulletJournal.Core.Services.Builders;
using BulletJournal.Models.Bullet;
using BulletJournal.Models.Collection;

namespace BulletJournal.Data.Services.Builders
{
    public class FutureLogBuilder : IFutureLogBuilder
    {
        public FutureLog BuildDefaultFutureLog()
        {
            var futureLog = new FutureLog
            {
                Name = "Log Futuro",
                Description = "O Log Futuro deste ano",
                Year = DateTime.Now.Year
            };

            for (int i = 1; i <= 12; i++)
            {
                var month = (Models.Calendar.Month)i;

                var futureLogMonth = new FutureLogMonth
                {
                    Month = month,
                    Log = new Models.Log()
                };

                for (int j = 0; j < 30; j++)
                {
                    futureLogMonth.Log.Bullets.Add((j + 1), new Note { Description = $"Test Bullet n. {j + 1}" });
                }

                futureLog.Months[month] = futureLogMonth;
            }

            return futureLog;
        }
    }
}
