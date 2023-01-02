using BulletJournal.Core.Services.Builders;
using BulletJournal.Core.Services.Managers;
using BulletJournal.Models;
using BulletJournal.Models.Calendar;
using BulletJournal.Models.Options;

namespace BulletJournal.Data.Services.Builders
{
    public class JournalBuilder : IJournalBuilder
    {
        private readonly IJournalManager _journalManager;
        private readonly IFutureLogBuilder _futureLogBuilder;
        private readonly IDailyLogBuilder _dailyLogBuilder;
        private readonly IMonthlyLogBuilder _monthlyLogBuilder;

        public JournalBuilder(IJournalManager journalManager, IFutureLogBuilder futureLogBuilder, IDailyLogBuilder dailyLogBuilder, IMonthlyLogBuilder monthlyLogBuilder)
        {
            _journalManager = journalManager;
            _futureLogBuilder = futureLogBuilder;
            _dailyLogBuilder = dailyLogBuilder;
            _monthlyLogBuilder = monthlyLogBuilder;
        }

        public Journal BuildJournal(Journal journal, JournalBuilderOptions builderOptions)
        {
            if (journal == null)
                throw new ArgumentNullException("No journal to build");

            _journalManager.SetJournal(journal);

            var now = DateTime.UtcNow;
            journal.Index = new Models.Index();
            journal.IsDefault = true;

            if (builderOptions.BuildFutureLog)
            {
                var futureLog = _futureLogBuilder.BuildDefaultFutureLog();
                _journalManager.AddCollection(futureLog);
            }

            if (builderOptions.BuildDailyLog)
            {
                var dailyLogs = _dailyLogBuilder.BuildDailyLogsForMonth((Month)now.Month, now.Year);
                foreach (var dailyLog in dailyLogs)
                {
                    _journalManager.AddCollection(dailyLog.Value);
                }
            }

            if (builderOptions.BuildMonthlyLog)
            {
                var monthlyLog = _monthlyLogBuilder.BuildDefaultMonthlyLog();
                _journalManager.AddCollection(monthlyLog);
            }

            return _journalManager.Journal;
        }
    }
}
