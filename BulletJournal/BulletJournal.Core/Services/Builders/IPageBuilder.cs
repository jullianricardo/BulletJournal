using BulletJournal.Models;
using BulletJournal.Models.Collection;
using System.Collections.Generic;

namespace BulletJournal.Core.Services.Builders
{
    public interface IPageBuilder
    {
        SortedList<int, Page> BuildPages(List<Collection> collections, Page lastPage);
    }
}
