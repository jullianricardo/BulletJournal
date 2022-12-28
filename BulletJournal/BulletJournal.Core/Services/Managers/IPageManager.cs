using BulletJournal.Models;
using BulletJournal.Models.Collection;
using System.Collections.Generic;

namespace BulletJournal.Core.Services.Managers
{
    public interface IPageManager
    {
        List<Page> BuildPages(List<Collection> collections, int lastPageNumber);
    }
}
