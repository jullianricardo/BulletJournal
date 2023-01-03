using Azure;
using BulletJournal.Core.Services.Builders;
using BulletJournal.Core.Services.Managers;
using BulletJournal.Models;
using BulletJournal.Models.Collection;
using System.Web;

namespace BulletJournal.Data.Services.Managers
{
    public class JournalManager : IJournalManager
    {
        private readonly IPageBuilder _pageBuilder;
        private readonly IPageManager _pageManager;
        private readonly ISpreadBuilder _spreadBuilder;

        private SortedList<int, Page> _pages;

        public JournalManager(IPageBuilder pageBuilder, IPageManager pageManager, ISpreadBuilder spreadBuilder)
        {
            _pageBuilder = pageBuilder;
            _pageManager = pageManager;
            _spreadBuilder = spreadBuilder;

            _pages = new SortedList<int, Page>();
        }

        public Journal Journal { get; private set; }

        public void AddCollection(Collection collection)
        {
            Journal.Index.AddCollection(collection);

            Page currentPage = null;
            int lastPageNumber = 0;

            var lastSpread = Journal.Spreads.LastOrDefault();
            if (lastSpread.Value != null)
            {
                var lastPage = lastSpread.Value.GetLastPage();
                if (lastPage != null)
                {
                    lastPageNumber = lastPage.Number;
                    _pageManager.SetPage(lastPage);
                    if (_pageManager.CollectionFitsInPage(collection))
                    {
                        currentPage = lastPage;
                    }
                }
            }

            if (currentPage != null)
            {
                _pageManager.SetPage(currentPage);
                _pageManager.AddCollection(collection);
            }
            else
            {
                int startPageNumber = lastPageNumber + 1;
                var pages = _pageBuilder.BuildPages(new List<Collection> { collection }, startPageNumber);
                var spreads = _spreadBuilder.BuildSpreadsFromPages(pages, lastSpread.Value, lastSpread.Key);

                foreach (var spread in spreads)
                {
                    Journal.Spreads[spread.Key] = spread.Value;
                }
            }
        }

        public void SetJournal(Journal journal)
        {
            Journal = journal;

            if (Journal.Spreads.Any())
            {
                _pages = _spreadBuilder.GetPagesFromSpreads(Journal.Spreads);
            }

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


        public void SetCurrentPage(string pageId)
        {
            bool pageExists = _pages.Any(x => x.Value.Id == pageId);
            if (!pageExists)
                throw new InvalidOperationException($"Page with Id {pageId} does not exist for this journal");

            Journal.CurrentPage = pageId;
        }

        public void SetCurrentPage(int pageNumber)
        {

            bool pageExists = _pages.ContainsKey(pageNumber);
            if (!pageExists)
                throw new InvalidOperationException($"Page n. {pageNumber} does not exist for this journal");

            string pageId = _pages[pageNumber].Id;
            Journal.CurrentPage = pageId;
        }


        public Page FindPage(string pageId)
        {
            var page = _pages.FirstOrDefault(x => x.Value.Id == pageId);
            return page.Value;
        }

        public Page FindPage(int pageNumber)
        {
            if (!_pages.ContainsKey(pageNumber))
                return null;

            var page = _pages[pageNumber];
            return page;
        }
    }
}
