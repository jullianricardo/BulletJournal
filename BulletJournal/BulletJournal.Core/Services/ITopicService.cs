using BulletJournal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BulletJournal.Core.Services
{
    public interface ITopicService
    {
        Task<Topic> GetTopicById(string id);
        Task<IEnumerable<Topic>> GetTopicsByIndexId(string indexId);
        Task CreateTopic(Topic topic);
        Task CreateIndexTopics(string indexId, IEnumerable<Topic> topics);
        Task UpdateTopic(Topic topic);
        Task DeleteTopic(string topicId);
    }
}
