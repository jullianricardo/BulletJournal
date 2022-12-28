using BulletJournal.Models;
using BulletJournal.Models.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Web.Services.Managers.Interfaces
{
    public interface IPageManager
    {
        List<Page> BuildPages(List<Collection> collections, int lastPageNumber);
    }
}
