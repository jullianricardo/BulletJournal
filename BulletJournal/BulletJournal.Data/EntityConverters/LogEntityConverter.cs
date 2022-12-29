using BulletJournal.Data.EntityConverters.Interfaces;
using BulletJournal.Data.Model.Collection;
using BulletJournal.Models;
using BulletJournal.Models.Bullet;

namespace BulletJournal.Data.EntityConverters
{
    public class LogEntityConverter : ILogEntityConverter
    {
        private readonly IBulletEntityConverter _bulletEntityConverter;

        public LogEntityConverter(IBulletEntityConverter bulletEntityConverter)
        {
            _bulletEntityConverter = bulletEntityConverter;
        }

        public Log ConvertFromDatabaseEntity(LogEntity databaseEntity, bool deepConversion = true)
        {
            var modelEntity = new Log
            {
                Id = databaseEntity.Id,
                Description = databaseEntity.Description,
                Name = databaseEntity.Name,
                Order = databaseEntity.Order,
                CreatedAt = databaseEntity.CreatedAt,
                UpdatedAt = databaseEntity.UpdatedAt,
            };

            if (deepConversion)
            {
                if (databaseEntity.Bullets != null)
                {
                    var pages = databaseEntity.Bullets.Select(x => _bulletEntityConverter.ConvertFromDatabaseEntity(x));
                    var sortedPageList = new SortedList<int, Bullet>(pages.ToDictionary(x => x.Order));
                }
            }

            return modelEntity;
        }

        public LogEntity ConvertFromModelEntity(Log modelEntity, bool deepConversion = true)
        {
            var databaseEntity = new LogEntity
            {
                Id = modelEntity.Id,
                Description = modelEntity.Description,
                Name = modelEntity.Name,
                Order = modelEntity.Order,
                CreatedAt = modelEntity.CreatedAt,
                UpdatedAt = modelEntity.UpdatedAt,
            };

            if (deepConversion)
            {
                if (modelEntity.Bullets != null)
                {
                    //var topics = modelEntity.Topics.Select(x => _topicEntityConverter.ConvertFromModelEntity(x));
                    //databaseEntity.Topics = new ObservableCollection<TopicEntity>(topics);
                }
            }

            return databaseEntity;
        }
    }
}
