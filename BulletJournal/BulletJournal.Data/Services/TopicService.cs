using BulletJournal.Core.Repositories;
using BulletJournal.Core.Services;
using BulletJournal.Models;

namespace BulletJournal.Data.Services
{
    public class TopicService : ITopicService
    {
        private readonly ITopicRepository _topicRepository;

        public TopicService(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public async Task<Topic> GetTopicById(string id)
        {
            return await _topicRepository.GetTopicById(id);
        }

        public async Task<IEnumerable<Topic>> GetTopicsByIndexId(string indexId)
        {
            return await _topicRepository.GetTopicsByIndexId(indexId);
        }

        public async Task CreateTopic(Topic topic)
        {
            await _topicRepository.CreateTopic(topic);
        }

        public async Task CreateIndexTopics(string indexId, IEnumerable<Topic> topics)
        {
            await _topicRepository.CreateIndexTopics(indexId, topics);
        }

        public async Task UpdateTopic(Topic topic)
        {
            await _topicRepository.UpdateTopic(topic);
        }

        public async Task DeleteTopic(string topicId)
        {
            await _topicRepository.DeleteTopic(topicId);
        }
    }
}
