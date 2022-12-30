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
                    Log = new Models.Log
                    {
                        Order = i,
                    }

                };

                for (int j = 1; j <= 30; j++)
                {
                    futureLogMonth.Log.Bullets.Add(j, new Note { Order = j, Description = $"Test Bullet n. {j}" });
                }

                futureLog.Months[month] = futureLogMonth;
            }

            return futureLog;
        }
    }
}
