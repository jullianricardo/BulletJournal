using BulletJournal.Core.Services.Builders;
using BulletJournal.Models;
using BulletJournal.Models.Options;
using BulletJournal.Web.Services.Interfaces;

namespace BulletJournal.Web.Services
{
    public class JournalService : BaseService, IJournalService
    {
        private const string JOURNALS_BASE_URL = "journals";
        private const string JOURNAL_BASE_URL = "journal";
        private readonly IJournalBuilder _journalBuilder;

        public JournalService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IJournalBuilder journalBuilder) : base(httpClientFactory, httpContextAccessor)
        {
            _journalBuilder = journalBuilder;
        }

        public async Task CreateJournal(Journal journal)
        {
            var url = JOURNAL_BASE_URL;
            var newJournal = _journalBuilder.BuildJournal(journal, new JournalBuilderOptions { BuildFutureLog = false, BuildMonthlyLog = false });
            await PostToEndpoint(url, newJournal);
        }

        public async Task<IList<Journal>> GetJournalsByOwner(string ownerId)
        {
            var url = string.Format("{0}/{1}", JOURNALS_BASE_URL, ownerId);
            var journals = await GetFromEndpoint<IList<Journal>>(url);
            return journals;
        }

        public async Task<Journal> GetOwnerDefaultJournal(string ownerId)
        {
            var url = string.Format("{0}/{1}/default", JOURNALS_BASE_URL, ownerId);
            var journal = await GetFromEndpoint<Journal>(url);
            return journal;
        }

        public async Task<Journal> GetJournalById(string id)
        {
            var url = string.Format("{0}/{1}", JOURNAL_BASE_URL, id);
            var journal = await GetFromEndpoint<Journal>(url);
            return journal;
        }
    }
}
