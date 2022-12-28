using BulletJournal.Core.Services.Builders;
using BulletJournal.Core.Services.Managers;
using BulletJournal.Models;
using BulletJournal.Models.Collection;

namespace BulletJournal.Data.Services.Managers
{
    public class JournalManager : IJournalManager
    {
        private readonly IPageManager _pageManager;
        private readonly ISpreadBuilder _spreadBuilder;

        public JournalManager(IPageManager pageManager, ISpreadBuilder spreadBuilder)
        {
            _pageManager = pageManager;
            _spreadBuilder = spreadBuilder;
        }

        public Journal Journal { get; private set; }

        public void AddCollection(Collection collection)
        {
            Journal.Index.AddCollection(collection);

            var lastSpread = Journal.Spreads.LastOrDefault();
            int lastPageNumber = 0;
            int lastSpreadNumber = 0;

            if (lastSpread.Value != null)
            {
                lastPageNumber = lastSpread.Value.GetLastPageNumber();
                lastSpreadNumber = lastSpread.Key;
            }

            var pages = _pageManager.BuildPages(new List<Collection> { collection }, lastPageNumber);
            var sortedPageList = new SortedList<int, Page>(pages.ToDictionary(x => x.Number));

            var spreads = _spreadBuilder.BuildSpreadsFromPages(sortedPageList, lastSpread.Value, lastSpreadNumber);

            foreach (var spread in spreads)
            {
                Journal.Spreads[spread.Key] = spread.Value;
            }
        }
        public void SetJournal(Journal journal)
        {
            Journal = journal;
        }
    }
}
