using BulletJournal.Core.Domain;
using BulletJournal.Core.Repositories;
using BulletJournal.Data.EntityConverters.Interfaces;
using BulletJournal.Data.Infrastructure;
using BulletJournal.Data.Model;
using BulletJournal.Data.Repositories.Base;
using BulletJournal.Models;
using Microsoft.EntityFrameworkCore;

namespace BulletJournal.Data.Repositories
{
    public class TopicRepository : BulletJournalRepository, ITopicRepository
    {
        private readonly DbSet<TopicEntity> _topics;
        private readonly DbSet<IndexEntity> _indexes;
        private readonly ITopicEntityConverter _topicEntityConverter;

        public TopicRepository(BulletJournalContext dbContext, ITopicEntityConverter topicEntityConverter) : base(dbContext)
        {
            _topics = dbContext.Topics;
            _indexes = dbContext.Indexes;
            _topicEntityConverter = topicEntityConverter;
        }

        public async Task<Topic> GetTopicById(string id)
        {
            var topicEntity = await _topics.FindAsync(id);
            if (topicEntity == null)
                return null;

            var topic = _topicEntityConverter.ConvertFromDatabaseEntity(topicEntity);
            return topic;
        }

        public async Task<IEnumerable<Topic>> GetTopicsByIndexId(string indexId)
        {
            var topics = await _topics.Where(x => x.IndexId == indexId)
                .Select(x => _topicEntityConverter.ConvertFromDatabaseEntity(x, true))
                .ToListAsync();

            return topics;

        }

        public async Task CreateTopic(Topic topic)
        {
            var topicEntity = _topicEntityConverter.ConvertFromModelEntity(topic);
            _topics.Add(topicEntity);
            await SaveChangesAsync();
        }

        public async Task CreateIndexTopics(string indexId, IEnumerable<Topic> topics)
        {

            foreach (var topic in topics)
            {
                var topicEntity = _topicEntityConverter.ConvertFromModelEntity(topic);
                topicEntity.IndexId = indexId;
                _topics.Add(topicEntity);
            }

            await SaveChangesAsync();
        }

        public async Task UpdateTopic(Topic topic)
        {
            var topicEntity = _topicEntityConverter.ConvertFromModelEntity(topic);
            var existingEntity = await _topics.FindAsync(topic.Id);
            if (existingEntity != null)
            {
                topicEntity.Patch(existingEntity);
                _topics.Update(existingEntity);

                await SaveChangesAsync();
            }
        }

        public async Task DeleteTopic(string topicId)
        {

            var topicEntity = await _topics.FindAsync(topicId);
            if (topicEntity != null)
            {
                _topics.Remove(topicEntity);
                await SaveChangesAsync();
            }
        }
    }
}
