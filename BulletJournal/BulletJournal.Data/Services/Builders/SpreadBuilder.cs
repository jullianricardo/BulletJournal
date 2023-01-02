using BulletJournal.Core.Services.Builders;
using BulletJournal.Models;

namespace BulletJournal.Data.Services.Builders
{
    public class SpreadBuilder : ISpreadBuilder
    {
        public SortedList<int, Spread> BuildSpreadsFromPages(SortedList<int, Page> pages, Spread lastSpread = null, int lastSpreadNumber = 0)
        {
            if (pages == null)
                return null;

            if (pages.Count == 0)
                return new SortedList<int, Spread>();

            var spreads = new SortedList<int, Spread>();
            Spread currentSpread = new Spread();
            int currentSpreadNumber = lastSpreadNumber + 1;

            if (lastSpread != null && lastSpread.Status == SpreadStatus.Incomplete)
            {
                currentSpread = lastSpread;
                currentSpreadNumber = lastSpreadNumber;
            }

            var lastPageNumber = pages.Last().Key;
            int currentPageNumber = pages.First().Key;

            bool isLastPage;

            do
            {
                var page = pages[currentPageNumber];

                if (currentSpread.Status == SpreadStatus.Full)
                {
                    spreads[currentSpreadNumber] = currentSpread;
                    currentSpread = new Spread();
                    currentSpreadNumber++;
                }

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

                isLastPage = currentPageNumber == lastPageNumber;

                if (isLastPage)
                {
                    spreads[currentSpreadNumber] = currentSpread;
                }

                currentPageNumber++;
            }
            while (!isLastPage);

            return spreads;
        }

        public SortedList<int, Page> GetPagesFromSpreads(SortedList<int, Spread> spreads)
        {
            var pages = new SortedList<int, Page>();

            foreach (var spread in spreads)
            {
                if (spread.Value.LeftPage != null)
                    pages.Add(spread.Value.LeftPage.Number, spread.Value.LeftPage);

                if (spread.Value.RightPage != null)
                    pages.Add(spread.Value.RightPage.Number, spread.Value.RightPage);
            }

            return pages;
        }
    }
}
