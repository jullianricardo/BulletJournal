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

                futureLog.Months[month] = futureLogMonth;
            }

            return futureLog;
        }
    }
}
