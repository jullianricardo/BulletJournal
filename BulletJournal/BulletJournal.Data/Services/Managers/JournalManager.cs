using BulletJournal.Models;
using BulletJournal.Models.Collection;
using BulletJournal.Core.Services.Managers;

namespace BulletJournal.Data.Services.Managers
{
    public class JournalManager : IJournalManager
    {
        private readonly IPageManager _pageManager;

        public JournalManager(IPageManager pageManager)
        {
            _pageManager = pageManager;
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

            int currentSpreadNumber = lastSpreadNumber + 1;
            var spreads = BuildSpreads(pages, lastSpread.Value);

            foreach (var spread in spreads)
            {
                Journal.Spreads.Add(currentSpreadNumber, spread);
                currentSpreadNumber++;
            }
        }

        public List<Spread> BuildSpreads(List<Page> pages, Spread lastSpread = null)
        {
            var spreads = new List<Spread>();

            if (lastSpread != null && lastSpread.Status == SpreadStatus.Incomplete)
                spreads.Add(lastSpread);

            Spread currentSpread = lastSpread ?? new Spread();

            var pageCount = pages.Count;
            for (int i = 0; i < pageCount; i++)
            {
                var page = pages[i];

                switch (currentSpread.Status)
                {
                    case SpreadStatus.Empty:
                        currentSpread.LeftPage = page;
                        break;

                    case SpreadStatus.Incomplete:
                        currentSpread.RightPage = page;
                        break;

                    default:
                        break;
                }

                bool isLastPage = (i + 1) == pageCount;
                if (currentSpread.Status == SpreadStatus.Full || (currentSpread.Status == SpreadStatus.Incomplete && isLastPage))
                {
                    spreads.Add(currentSpread);
                    currentSpread = new Spread();
                }
            }

            return spreads;
        }

        public void SetJournal(Journal journal)
        {
            Journal = journal;
        }
    }
}
