using BulletJournal.Models;
using BulletJournal.Models.Collection;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Collections.Generic;

namespace BulletJournal.Core.Services.Managers
{
    public interface IJournalManager
    {
        Journal Journal { get; }

        void SetJournal(Journal journal);

        void AddCollection(Collection collection);



        Page FindPage(string pageId);

        Page FindPage(int pageNumber);


        void SetCurrentPage(string pageId);

        void SetCurrentPage(int pageNumber);


        Spread GetCurrentSpread();
    }
}
