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

        public Spread GetCurrentSpread()
        {
            if (Journal.Spreads == null || !Journal.Spreads.Any())
                return null;

            if (!string.IsNullOrWhiteSpace(Journal.CurrentPage))
            {
                var spread = Journal.Spreads.FirstOrDefault(x => x.Value.LeftPage?.Id == Journal.CurrentPage || x.Value.RightPage?.Id == Journal.CurrentPage);
                return spread.Value;
            }

            var lastSpread = Journal.Spreads.LastOrDefault();
            return lastSpread.Value;
        }
    }
}
