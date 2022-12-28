using BulletJournal.Models;
using BulletJournal.Web.Models.Options;
using BulletJournal.Web.Services.Builders.Interfaces;
using BulletJournal.Web.Services.Interfaces;
using BulletJournal.Web.Services.Managers.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulletJournal.Web.Services.Builders
{
    public class JournalBuilder : IJournalBuilder
    {
        private readonly ISettingsService _settingsService;
        private readonly IFutureLogBuilder _futureLogBuilder;
        private readonly IJournalManager _journalManager;

        public JournalBuilder(ISettingsService settingsService, IFutureLogBuilder futureLogBuilder, IJournalManager journalManager)
        {
            _settingsService = settingsService;
            _futureLogBuilder = futureLogBuilder;
            _journalManager = journalManager;
        }

        public Journal BuildJournal(Journal journal, JournalBuilderOptions builderOptions)
        {
            if (journal == null)
                throw new ArgumentNullException("No journal to build");

            _journalManager.SetJournal(journal);

            var now = DateTime.UtcNow;

            var index = new BulletJournal.Models.Index
            {
                CreatedAt = now
            };

            journal.Index = index;

            if (builderOptions.BuildFutureLog)
            {
                var futureLog = _futureLogBuilder.BuildDefaultFutureLog();
                futureLog.CreatedAt = now;
                _journalManager.AddCollection(futureLog);
            }

            return _journalManager.Journal;
        }
    }
}
