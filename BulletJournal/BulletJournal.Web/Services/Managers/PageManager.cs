using BulletJournal.Models;
using BulletJournal.Models.Collection;
using BulletJournal.Web.Services.Factories.Interfaces;
using BulletJournal.Web.Services.Interfaces;
using BulletJournal.Web.Services.Managers.Interfaces;

namespace BulletJournal.Web.Services.Managers
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

        public List<Page> BuildPages(List<Collection> collections, int lastPageNumber)
        {
            var pages = new List<Page>();

            var userSettings = _settingsService.GetUserSettings();

            int currentPageNumber = lastPageNumber + 1;
            var currentPage = new Page()
            {
                Number = currentPageNumber,
            };

            var fullListOfCollections = collections;
            if (userSettings.SplitCollectionsBetweenMultiplePages)
            {
                fullListOfCollections = new List<Collection>();

                foreach (var collection in collections)
                {
                    int collectionSize = collection.RetrieveCollectionSize();

                    if (collectionSize <= userSettings.DefaultPageSize)
                        fullListOfCollections.Add(collection);
                    else
                    {
                        var splittedCollections = SplitCollection(collection, userSettings.DefaultPageSize);
                        fullListOfCollections.AddRange(splittedCollections);
                    }
                }
            }

            foreach (var collection in fullListOfCollections)
            {
                if (userSettings.AllowMultipleCollectionsPerPage)
                {
                    int collectionSize = collection.RetrieveCollectionSize();
                    int currentPageSize = currentPage.CurrentSize;

                    int maxPageSize = userSettings.SplitCollectionsBetweenMultiplePages ? userSettings.DefaultPageSize : int.MaxValue;
                    int pageFreeSpace = maxPageSize - currentPageSize;

                    bool collectionFitsInPage = collectionSize <= pageFreeSpace;
                    if (!collectionFitsInPage)
                    {
                        pages.Add(currentPage);
                        currentPageNumber++;
                        currentPage = new Page
                        {
                            Number = currentPageNumber,
                        };
                    }
                }

                currentPage.Collections.Add(collection);

                if (collection == fullListOfCollections.Last())
                    pages.Add(currentPage);
            }

            return pages;
        }


        private List<Collection> SplitCollection(Collection collection, int defaultPageSize)
        {
            int pageSize = defaultPageSize > 0 ? defaultPageSize : 1;

            var collections = new List<Collection>();
            var currentCollection = _collectionFactory.CreateCollection(collection.Type);

            foreach (var currentLog in collection.Logs)
            {
                int currentCollectionSize = currentCollection.RetrieveCollectionSize();
                int collectionFreeSpace = pageSize - currentCollectionSize;

                int currentLogSize = currentLog.Value.GetLogSize();
                bool logFitsInCollection = currentLogSize <= collectionFreeSpace;
                if (!logFitsInCollection)
                {
                    collections.Add(currentCollection);
                    currentCollection = _collectionFactory.CreateCollection(collection.Type);
                }

                currentCollection.Logs.Add(currentLog.Key, currentLog.Value);

                if (currentLog.Key == collection.Logs.Last().Key)
                    collections.Add(currentCollection);
            }

            return collections;
        }
    }
}
