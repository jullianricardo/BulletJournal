using BulletJournal.Data.EntityConverters.Interfaces;
using BulletJournal.Data.Model;
using BulletJournal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Data.EntityConverters
{
    public class PageEntityConverter : IPageEntityConverter
    {
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

                //if (databaseEntity.Collections != null)
                //{
                //    var collections = databaseEntity.Collections.
                //} 
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
                    //var pages = _spreadBuilder.GetPagesFromSpreads(modelEntity.Spreads);
                    //var pageEntities = pages.Select(x => _pageEntityConverter.ConvertFromModelEntity(x.Value));
                    //databaseEntity.Pages = new System.Collections.ObjectModel.ObservableCollection<PageEntity>(pageEntities);
                }
            }

            return databaseEntity;
        }
    }
}
