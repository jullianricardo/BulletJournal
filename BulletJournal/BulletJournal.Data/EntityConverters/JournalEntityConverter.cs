using BulletJournal.Core.Services.Builders;
using BulletJournal.Data.EntityConverters.Interfaces;
using BulletJournal.Data.Model;
using BulletJournal.Models;

namespace BulletJournal.Data.EntityConverters
{
    public class JournalEntityConverter : IJournalEntityConverter
    {
        private readonly ISpreadBuilder _spreadBuilder;
        private readonly IPageEntityConverter _pageEntityConverter;
        private readonly IIndexEntityConverter _indexEntityConverter;

        public JournalEntityConverter(ISpreadBuilder spreadBuilder, IPageEntityConverter pageEntityConverter, IIndexEntityConverter indexEntityConverter)
        {
            _spreadBuilder = spreadBuilder;
            _pageEntityConverter = pageEntityConverter;
            _indexEntityConverter = indexEntityConverter;
        }

        public Journal ConvertFromDatabaseEntity(JournalEntity databaseEntity, bool deepConversion = true)
        {
            var modelEntity = new Journal
            {
                Id = databaseEntity.Id,
                Name = databaseEntity.Name,
                Description = databaseEntity.Description,
                Year = databaseEntity.Year,
                OwnerId = databaseEntity.OwnerId,
                IsDefault = databaseEntity.IsDefault,
                CreatedAt = databaseEntity.CreatedAt,
                UpdatedAt = databaseEntity.UpdatedAt,
            };

            if (deepConversion)
            {
                if (databaseEntity.Pages != null)
                {
                    var pages = databaseEntity.Pages.Select(x => _pageEntityConverter.ConvertFromDatabaseEntity(x));
                    var sortedPageList = new SortedList<int, Page>(pages.ToDictionary(x => x.Number));

                    var spreads = _spreadBuilder.BuildSpreadsFromPages(sortedPageList);
                    modelEntity.Spreads = spreads;
                }
            }

            return modelEntity;
        }
        public JournalEntity ConvertFromModelEntity(Journal modelEntity, bool deepConversion = true)
        {
            var databaseEntity = new JournalEntity
            {
                Id = modelEntity.Id,
                Name = modelEntity.Name,
                Description = modelEntity.Description,
                Year = modelEntity.Year,
                OwnerId = modelEntity.OwnerId,
                IsDefault = modelEntity.IsDefault,
                CreatedAt = modelEntity.CreatedAt,
                UpdatedAt = modelEntity.UpdatedAt,
            };

            if (deepConversion)
            {
                if (modelEntity.Index != null)
                {
                    var indexEntity = _indexEntityConverter.ConvertFromModelEntity(modelEntity.Index);
                    databaseEntity.Index = indexEntity;
                }

                if (modelEntity.Spreads != null)
                {
                    var pages = _spreadBuilder.GetPagesFromSpreads(modelEntity.Spreads);
                    var pageEntities = pages.Select(x => _pageEntityConverter.ConvertFromModelEntity(x.Value));
                    databaseEntity.Pages = new System.Collections.ObjectModel.ObservableCollection<PageEntity>(pageEntities);
                }
            }

            return databaseEntity;
        }
    }
}
