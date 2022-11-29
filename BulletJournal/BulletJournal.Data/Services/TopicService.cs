using BulletJournal.Core.Common;
using BulletJournal.Core.Domain;
using BulletJournal.Core.Services;
using BulletJournal.Data.Model;
using BulletJournal.Data.Repositories;
using BulletJournal.Models;
using Microsoft.EntityFrameworkCore;

namespace BulletJournal.Data.Services
{
    public class TopicService : ITopicService
    {
        private readonly IBulletJournalRepository _bulletJournalRepository;

        public TopicService(IBulletJournalRepository bulletJournalRepository)
        {
            _bulletJournalRepository = bulletJournalRepository;
        }

        public async Task<Topic> GetTopicById(string id)
        {
            var topicEntity = await _bulletJournalRepository.Topics
                .FirstOrDefaultAsync(x => x.Id == id);

            if (topicEntity == null)
                return null;

            var topic = topicEntity.ToModel(AbstractTypeFactory<Topic>.TryCreateInstance());
            return topic;
        }

        public async Task<IEnumerable<Topic>> GetTopicsByIndexId(string indexId)
        {
            var topicEntities = await _bulletJournalRepository.Topics
                .Where(x => x.IndexId == indexId).ToListAsync();

            if (topicEntities == null)
                return null;

            var topics = topicEntities.Select(x => x.ToModel(AbstractTypeFactory<Topic>.TryCreateInstance()));
            return topics;
        }

        public async Task SaveJournal(Journal journal)
        {
            var primaryKeyResolvingMap = new PrimaryKeyResolvingMap();
            var journalEntity = AbstractTypeFactory<JournalEntity>.TryCreateInstance().FromModel(journal, primaryKeyResolvingMap);
            journalEntity.CreatedAt = DateTime.Now;

            _bulletJournalRepository.Add(journalEntity);
            await _bulletJournalRepository.UnitOfWork.CommitAsync();
            primaryKeyResolvingMap.ResolvePrimaryKeys();
        }

        public async Task UpdateJournal(Journal journal)
        {
            var primaryKeyResolvingMap = new PrimaryKeyResolvingMap();

            var sourceEntity = AbstractTypeFactory<JournalEntity>.TryCreateInstance().FromModel(journal, primaryKeyResolvingMap);
            var targetEntity = await _bulletJournalRepository.Journals.FirstOrDefaultAsync(x => x.Id == journal.Id);
            if (targetEntity != null)
            {
                targetEntity.UpdatedAt = DateTime.Now;
                sourceEntity.Patch(targetEntity);

                _bulletJournalRepository.Update(targetEntity);
                await _bulletJournalRepository.UnitOfWork.CommitAsync();
                primaryKeyResolvingMap.ResolvePrimaryKeys();
            }
        }

        public async Task DeleteJournal(string journalId)
        {
            var targetEntity = await _bulletJournalRepository.Journals.FirstOrDefaultAsync(x => x.Id == journalId);
            if (targetEntity != null)
            {
                _bulletJournalRepository.Remove(targetEntity);
                await _bulletJournalRepository.UnitOfWork.CommitAsync();
            }
        }

        public Task CreateTopic(Topic topic) => throw new NotImplementedException();
        public Task CreateIndexTopics(string indexId, IEnumerable<Topic> topics) => throw new NotImplementedException();
        public Task UpdateTopic(Topic topic) => throw new NotImplementedException();
        public Task DeleteTopic(string topicId) => throw new NotImplementedException();
    }
}
