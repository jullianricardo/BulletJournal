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
    public class TopicEntityConverter : ITopicEntityConverter
    {
        public Topic ConvertFromDatabaseEntity(TopicEntity databaseEntity, bool deepConversion = true)
        {
            var modelEntity = new Topic
            {
                Id = databaseEntity.Id,
                Title = databaseEntity.Title,
                IndexId = databaseEntity.IndexId,
                PageNumbers = databaseEntity.PageNumbers.Split(';').ToList(),
                CreatedAt = databaseEntity.CreatedAt,
                UpdatedAt = databaseEntity.UpdatedAt,
            };

            return modelEntity;
        }

        public TopicEntity ConvertFromModelEntity(Topic modelEntity, bool deepConversion = true)
        {
            var databaseEntity = new TopicEntity
            {
                Id = modelEntity.Id,
                Title = modelEntity.Title,
                IndexId = modelEntity.IndexId,
                PageNumbers = string.Join(';', modelEntity.PageNumbers),
                CreatedAt = modelEntity.CreatedAt,
                UpdatedAt = modelEntity.UpdatedAt,
            };

            return databaseEntity;
        }
    }
}
