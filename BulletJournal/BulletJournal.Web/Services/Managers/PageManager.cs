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
    public class PageManager : IPageManager
    {
        private readonly ISettingsService _settingsService;

        public PageManager(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public List<Page> BuildPages(IEnumerable<Collection> collections, int lastPageNumber)
        {
            var pages = new List<BulletJournal.Models.Page>();


            return pages;
        }
    }
}
