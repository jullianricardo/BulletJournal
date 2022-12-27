using BulletJournal.Models;
using BulletJournal.Web.Models.Options;
using BulletJournal.Web.Services.Builders.Interfaces;
using BulletJournal.Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulletJournal.Web.Services.Builders
{
    public class JournalBuilder : IJournalBuilder
    {
        private readonly ISettingsService _settingsService;
        private readonly IFutureLogBuilder _futureLogBuilder;

        public JournalBuilder(ISettingsService settingsService, IFutureLogBuilder futureLogBuilder)
        {
            _settingsService = settingsService;
            _futureLogBuilder = futureLogBuilder;
        }

        public Journal BuildJournal(Journal journal, JournalBuilderOptions builderOptions)
        {
            if (journal == null)
                throw new ArgumentNullException("No journal to build");

            var now = DateTime.UtcNow;

            var index = new BulletJournal.Models.Index
            {
                CreatedAt = now
            };

            journal.Index = index;

            if (builderOptions.BuildFutureLog)
            {
                var futureLog = _futureLogBuilder.BuildDefaultFutureLog();
                journal.Index.AddCollection(futureLog);
            }

            return journal;
        }
    }
}
