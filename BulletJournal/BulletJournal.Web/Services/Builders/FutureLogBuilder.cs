using BulletJournal.Models.Bullet;
using BulletJournal.Models.Collection;
using BulletJournal.Web.Services.Builders.Interfaces;

namespace BulletJournal.Web.Services.Builders
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
                var month = (BulletJournal.Models.Calendar.Month)i;

                var futureLogMonth = new FutureLogMonth
                {
                    Month = month,
                    Log = new Log()
                };

                for (int j = 0; j < 30; j++)
                {
                    futureLogMonth.Log.Bullets.Add(new Note { Description = $"Test Bullet n. {j + 1}" });
                }

                futureLog.Months[month] = futureLogMonth;
            }

            return futureLog;
        }
    }
}
