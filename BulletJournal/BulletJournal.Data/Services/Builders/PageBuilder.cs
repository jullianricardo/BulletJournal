using BulletJournal.Core.Services;
using BulletJournal.Core.Services.Builders;
using BulletJournal.Core.Services.Factories;
using BulletJournal.Core.Services.Managers;
using BulletJournal.Models;
using BulletJournal.Models.Collection;
using System.Collections.Generic;

namespace BulletJournal.Data.Services.Builders
{
    public class PageBuilder : IPageBuilder
    {
        private readonly IPageManager _pageManager;
        private readonly ISettingsService _settingsService;
        private readonly ICollectionFactory _collectionFactory;

        public PageBuilder(IPageManager pageManager, ISettingsService settingsService, ICollectionFactory collectionFactory)
        {
            _pageManager = pageManager;
            _settingsService = settingsService;
            _collectionFactory = collectionFactory;
        }

        public SortedList<int, Page> BuildPages(List<Collection> collections, int startPageNumber = 0)
        {
            var pages = new SortedList<int, Page>();
            var userSettings = _settingsService.GetUserSettings();

            var fullListOfCollections = collections;
            //if (userSettings.SplitCollectionsBetweenMultiplePages)
            //{
            //    fullListOfCollections = FlattenCollections(collections);
            //}

            int currentPageNumber = 1;
            if (startPageNumber > 0)
                currentPageNumber = startPageNumber;

            var currentPage = new Page()
            {
                Number = currentPageNumber,
            };

            //int currentCollectionNumber = 1;
            //var lastCollection = currentPage.Collections.LastOrDefault();

            //if (lastCollection.Key > 0)
            //    currentCollectionNumber = lastCollection.Key + 1;

            _pageManager.SetPage(currentPage);

            int fullListOfCollectionsCount = fullListOfCollections.Count;

            for (int i = 0; i < fullListOfCollections.Count; i++)
            {
                var collection = fullListOfCollections[i];
                bool collectionFitsInPage = _pageManager.CollectionFitsInPage(collection);

                if (!collectionFitsInPage || (currentPage.HasCollection && !userSettings.AllowMultipleCollectionsPerPage))
                {
                    pages[currentPageNumber] = currentPage;
                    currentPageNumber++;
                    currentPage = new Page
                    {
                        Number = currentPageNumber,
                    };
                    _pageManager.SetPage(currentPage);
                }

                _pageManager.AddCollection(collection);

                if (!collectionFitsInPage)
                {
                    if (userSettings.SplitCollectionsBetweenMultiplePages)
                    {
                        int freePageSize = _pageManager.GetPageFreeSize();
                        var splitCollections = SplitCollection(collection, freePageSize);

                        for (int j = 1; j <= splitCollections.Count; j++)
                        {
                            if (i > 1)
                            {
                                pages[currentPageNumber] = currentPage;
                                currentPageNumber++;
                                currentPage = new Page
                                {
                                    Number = currentPageNumber,
                                };
                                _pageManager.SetPage(currentPage);
                            }

                            _pageManager.AddCollection(collection);
                        }
                    }
                }

                if ((i + 1) == fullListOfCollectionsCount)
                    pages[currentPageNumber] = currentPage;
            }


            //for (int i = 0; i < fullListOfCollections.Count; i++)
            //{
            //    var collection = fullListOfCollections[i];
            //    if (userSettings.AllowMultipleCollectionsPerPage)
            //    {
            //        int collectionSize = collection.RetrieveCollectionSize();
            //        int currentPageSize = currentPage.CurrentSize;

            //        int maxPageSize = userSettings.SplitCollectionsBetweenMultiplePages ? userSettings.DefaultPageSize : int.MaxValue;
            //        int pageFreeSpace = maxPageSize - currentPageSize;

            //        bool collectionFitsInPage = collectionSize <= pageFreeSpace;
            //        if (!collectionFitsInPage)
            //        {
            //            pages.Add(currentPageNumber, currentPage);
            //            currentPageNumber++;
            //            currentPage = new Page
            //            {
            //                Number = currentPageNumber,
            //            };

            //            currentCollectionNumber = 1;
            //        }
            //    }

            //    currentPage.Collections.Add(currentCollectionNumber, collection);
            //    currentCollectionNumber++;

            //    if ((i + 1) == fullListOfCollectionsCount)
            //        pages.Add(currentPageNumber, currentPage);
            //}

            return pages;
        }

        private List<Collection> FlattenCollections(List<Collection> collections)
        {
            var userSettings = _settingsService.GetUserSettings();
            var fullListOfCollections = new List<Collection>();
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

            return fullListOfCollections;
        }

        private List<Collection> SplitCollection(Collection collection, int maxPageSize)
        {
            var userSettings = _settingsService.GetUserSettings();
            int defaultPageSize = userSettings.DefaultPageSize;

            if (maxPageSize == 0)
                maxPageSize = defaultPageSize;

            var collections = new List<Collection>();
            var currentCollection = _collectionFactory.CreateCollection(collection.Type);

            int firstLogNumber = collection.Logs.First().Key;
            int lastLogNumber = collection.Logs.Last().Key;

            for (int i = firstLogNumber; i <= lastLogNumber; i++)
            {
                var currentLog = collection.Logs[i];
                int currentCollectionSize = currentCollection.RetrieveCollectionSize();
                int pageSize = i == firstLogNumber ? maxPageSize : defaultPageSize;
                int collectionFreeSpace = pageSize - currentCollectionSize;

                int currentLogSize = currentLog.GetLogSize();
                bool logFitsInCollection = currentLogSize <= collectionFreeSpace;
                if (!logFitsInCollection)
                {
                    collections.Add(currentCollection);
                    currentCollection = _collectionFactory.CreateCollection(collection.Type);
                }

                currentCollection.Logs.Add(i, currentLog);

                if (i == lastLogNumber)
                    collections.Add(currentCollection);
            }

            //foreach (var currentLog in collection.Logs)
            //{
            //    int currentCollectionSize = currentCollection.RetrieveCollectionSize();
            //    int collectionFreeSpace = pageSize - currentCollectionSize;

            //    int currentLogSize = currentLog.Value.GetLogSize();
            //    bool logFitsInCollection = currentLogSize <= collectionFreeSpace;
            //    if (!logFitsInCollection)
            //    {
            //        collections.Add(currentCollection);
            //        currentCollection = _collectionFactory.CreateCollection(collection.Type);
            //    }

            //    currentCollection.Logs.Add(currentLog.Key, currentLog.Value);

            //    if (currentLog.Key == collection.Logs.Last().Key)
            //        collections.Add(currentCollection);
            //}

            return collections;
        }
    }
}
