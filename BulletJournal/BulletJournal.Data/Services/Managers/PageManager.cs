using BulletJournal.Models;
using BulletJournal.Models.Collection;
using BulletJournal.Core.Services;
using BulletJournal.Core.Services.Managers;
using BulletJournal.Core.Services.Factories;

namespace BulletJournal.Data.Services.Managers
{
    public class PageManager : IPageManager
    {
        private readonly ISettingsService _settingsService;
        private readonly ICollectionFactory _collectionFactory;

        public PageManager(ISettingsService settingsService, ICollectionFactory collectionFactory)
        {
            _settingsService = settingsService;
            _collectionFactory = collectionFactory;
        }

        public Page Page { get; private set; }

        public void SetPage(Page page)
        {
            Page = page;
        }

        public void AddCollection(Collection collection)
        {
            int currentCollectionNumber = 1;
            if (Page.Collections.Any())
            {
                var lastCollection = Page.Collections.Last();
                currentCollectionNumber = lastCollection.Key;
            }

            Page.Collections.Add(currentCollectionNumber + 1, collection);
        }

        public bool CollectionFitsInPage(Collection collection)
        {
            bool collectionFitsInPage = collection.RetrieveCollectionSize() <= GetPageFreeSize();
            return collectionFitsInPage;

        }

        public int GetPageFreeSize()
        {
            var userSettings = _settingsService.GetUserSettings();
            int defaultPageSize = userSettings.DefaultPageSize;

            int currentPageSize = Page.CurrentSize;
            int pageFreeSize = defaultPageSize - currentPageSize;
            return pageFreeSize;
        }
    }
}
