using BulletJournal.Models;
using BulletJournal.Models.Collection;
using System.Collections.Generic;

namespace BulletJournal.Core.Services.Managers
{
    public interface IJournalManager
    {
        Journal Journal { get; }

        void SetJournal(Journal journal);

        void AddCollection(Collection collection);

        List<Spread> BuildSpreads(List<Page> pages, Spread lastSpread = null);
    }
}
