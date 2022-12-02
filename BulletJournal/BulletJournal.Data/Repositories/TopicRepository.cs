using BulletJournal.Core.Domain;
using BulletJournal.Core.Repositories;
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

        public TopicRepository(BulletJournalContext dbContext) : base(dbContext)
        {
            _topics = dbContext.Topics;
            _indexes = dbContext.Indexes;
        }

        public async Task<Topic> GetTopicById(string id)
        {
            var topicEntity = await _topics.FindAsync(id);
            if (topicEntity == null)
                return null;

            var topic = topicEntity.ToModel(AbstractTypeFactory<Topic>.TryCreateInstance());
            return topic;
        }

        public async Task<IEnumerable<Topic>> GetTopicsByIndexId(string indexId)
        {
            var topics = await _topics.Where(x => x.IndexId == indexId)
                .Select(x => x.ToModel(AbstractTypeFactory<Topic>.TryCreateInstance()))
                .ToListAsync();

            return topics;

        }

        public async Task CreateTopic(Topic topic)
        {
            var topicEntity = AbstractTypeFactory<TopicEntity>.TryCreateInstance().FromModel(topic, new Core.Common.PrimaryKeyResolvingMap());
            topicEntity.CreatedAt = DateTime.Now;
            _topics.Add(topicEntity);
            await SaveChangesAsync();
        }

        public async Task CreateIndexTopics(string indexId, IEnumerable<Topic> topics)
        {

            foreach (var topic in topics)
            {
                var topicEntity = AbstractTypeFactory<TopicEntity>.TryCreateInstance().FromModel(topic, new Core.Common.PrimaryKeyResolvingMap());
                topicEntity.IndexId = indexId;
                topicEntity.CreatedAt = DateTime.Now;
                _topics.Add(topicEntity);
            }

            await SaveChangesAsync();
        }

        public async Task UpdateTopic(Topic topic)
        {
            var topicEntity = AbstractTypeFactory<TopicEntity>.TryCreateInstance().FromModel(topic, new Core.Common.PrimaryKeyResolvingMap());
            var existingEntity = await _topics.FindAsync(topic.Id);
            if (existingEntity != null)
            {
                topicEntity.Patch(existingEntity);
                existingEntity.UpdatedAt = DateTime.Now;
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
