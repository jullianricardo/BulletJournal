using BulletJournal.Data.EntityConverters.Interfaces;
using BulletJournal.Data.Model;
using BulletJournal.Models;
using BulletJournal.Models.Collection;

namespace BulletJournal.Data.EntityConverters
{
    public class PageEntityConverter : IPageEntityConverter
    {
        private readonly ICollectionEntityConverter _collectionEntityConverter;

        public PageEntityConverter(ICollectionEntityConverter collectionEntityConverter)
        {
            _collectionEntityConverter = collectionEntityConverter;
        }

        public Page ConvertFromDatabaseEntity(PageEntity databaseEntity, bool deepConversion = true)
        {
            var modelEntity = new Page
            {
                Id = databaseEntity.Id,
                Number = databaseEntity.Number,
                Title = databaseEntity.Title,
                CreatedAt = databaseEntity.CreatedAt,
                UpdatedAt = databaseEntity.UpdatedAt,
            };

            if (deepConversion)
            {
                if (databaseEntity.Collections != null)
                {
                    var collections = databaseEntity.Collections.Select(x => _collectionEntityConverter.ConvertFromDatabaseEntity(x));
                    modelEntity.Collections = new SortedList<int, Collection>(collections.Select((x, i) => new { Item = x, Index = (i + 1) }).ToDictionary(x => x.Index, x => x.Item));
                }
            }

            return modelEntity;
        }

        public PageEntity ConvertFromModelEntity(Page modelEntity, bool deepConversion = true)
        {
            var databaseEntity = new PageEntity
            {
                Id = modelEntity.Id,
                Number = modelEntity.Number,
                Title = modelEntity.Title,
                CreatedAt = modelEntity.CreatedAt,
                UpdatedAt = modelEntity.UpdatedAt,
            };

            if (deepConversion)
            {
                if (modelEntity.Collections != null)
                {
                    var collectionEntities = modelEntity.Collections.Select(x => _collectionEntityConverter.ConvertFromModelEntity(x.Value));
                    databaseEntity.Collections = new System.Collections.ObjectModel.ObservableCollection<Model.Collection.CollectionEntity>(collectionEntities);
                }
            }

            return databaseEntity;
        }
    }
}
