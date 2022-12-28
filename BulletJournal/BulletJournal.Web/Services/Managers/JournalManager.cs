using BulletJournal.Core.Services;
using BulletJournal.Models;
using BulletJournal.Models.Collection;
using BulletJournal.Web.Services.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Web.Services.Managers
{
    public class JournalManager : IJournalManager
    {
        private readonly ISettingsService _settingsService;
        private readonly IPageManager _pageManager;
        private Journal _journal;

        public JournalManager(ISettingsService settingsService, IPageManager pageManager)
        {
            _settingsService = settingsService;
            _pageManager = pageManager;
        }

        //public Journal Journal
        //{
        //    get
        //    {
        //        return _journal;
        //    }
        //    private set
        //    {
        //        _journal = value;
        //    }
        //}

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

            var pages = _pageManager.BuildPages(new[] { collection }, lastPageNumber);

            int currentSpreadNumber = lastSpreadNumber + 1;
            var spreads = BuildSpreads(pages, lastSpread.Value);

            foreach (var spread in spreads)
            {
                Journal.Spreads.Add(currentSpreadNumber, spread);
                currentSpreadNumber++;
            }
        }

        private List<Spread> BuildSpreads(List<Page> pages, Spread lastSpread = null)
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
