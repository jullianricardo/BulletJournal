using BulletJournal.Data.EntityConverters.Interfaces;
using BulletJournal.Data.Model;
using System.Collections.ObjectModel;

namespace BulletJournal.Data.EntityConverters
{
    public class IndexEntityConverter : IIndexEntityConverter
    {
        private readonly ITopicEntityConverter _topicEntityConverter;

        public IndexEntityConverter(ITopicEntityConverter topicEntityConverter)
        {
            _topicEntityConverter = topicEntityConverter;
        }

        public Models.Index ConvertFromDatabaseEntity(IndexEntity databaseEntity, bool deepConversion = true)
        {
            var modelEntity = new Models.Index
            {
                Id = databaseEntity.Id,
                JournalId = databaseEntity.JournalId,
                CreatedAt = databaseEntity.CreatedAt,
                UpdatedAt = databaseEntity.UpdatedAt,
            };

            if (deepConversion)
            {
                if (databaseEntity.Topics != null)
                {
                    var topics = databaseEntity.Topics.Select(x => _topicEntityConverter.ConvertFromDatabaseEntity(x));
                    modelEntity.Topics = topics.ToList();
                }
            }

            return modelEntity;
        }
        public IndexEntity ConvertFromModelEntity(Models.Index modelEntity, bool deepConversion = true)
        {

            var databaseEntity = new IndexEntity
            {
                Id = modelEntity.Id,
                JournalId = modelEntity.JournalId,
                CreatedAt = modelEntity.CreatedAt,
                UpdatedAt = modelEntity.UpdatedAt,
            };

            if (deepConversion)
            {
                if (modelEntity.Topics != null)
                {
                    var topics = modelEntity.Topics.Select(x => _topicEntityConverter.ConvertFromModelEntity(x));
                    databaseEntity.Topics = new ObservableCollection<TopicEntity>(topics);
                }
            }

            return databaseEntity;

        }
    }
}
