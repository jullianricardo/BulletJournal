using BulletJournal.Models;
using System.Collections.Generic;

namespace BulletJournal.Core.Services.Builders
{
    public interface ISpreadBuilder
    {
        SortedList<int, Spread> BuildSpreadsFromPages(SortedList<int, Page> pages, Spread lastSpread = null, int lastSpreadNumber = 0);

        SortedList<int, Page> GetPagesFromSpreads(SortedList<int, Spread> spreads);
    }
}
