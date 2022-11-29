using BulletJournal.Core.Common;
using BulletJournal.Core.Domain;
using BulletJournal.Core.Services;
using BulletJournal.Data.Model;
using BulletJournal.Data.Repositories;
using BulletJournal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Data.Services
{
    public class IndexService : IIndexService
    {
        private readonly IBulletJournalRepository _bulletJournalRepository;

        public IndexService(IBulletJournalRepository bulletJournalRepository)
        {
            _bulletJournalRepository = bulletJournalRepository;
        }

        public async Task<Models.Index> GetIndexById(string id)
        {
            var indexEntity = await _bulletJournalRepository.Indexes
                //.Include(x => x.Topics)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (indexEntity == null)
                return null;

            var index = indexEntity.ToModel(AbstractTypeFactory<Models.Index>.TryCreateInstance());
            return index;
        }

        public async Task<Models.Index> GetIndexByJournalId(string journalId)
        {
            var indexEntity = await _bulletJournalRepository.Indexes
                //.Include(x => x.Topics)
                .FirstOrDefaultAsync(x => x.JournalId == journalId);

            if (indexEntity == null)
                return null;

            var index = indexEntity.ToModel(AbstractTypeFactory<Models.Index>.TryCreateInstance());
            return index;
        }

        public async Task CreateIndex(Models.Index index)
        {
            var primaryKeyResolvingMap = new PrimaryKeyResolvingMap();
            var indexEntity = AbstractTypeFactory<IndexEntity>.TryCreateInstance().FromModel(index, primaryKeyResolvingMap);
            indexEntity.CreatedAt = DateTime.Now;

            _bulletJournalRepository.Add(indexEntity);
            await _bulletJournalRepository.UnitOfWork.CommitAsync();
            primaryKeyResolvingMap.ResolvePrimaryKeys();
        }

        public async Task UpdateIndex(Models.Index index)
        {
            var primaryKeyResolvingMap = new PrimaryKeyResolvingMap();

            var sourceEntity = AbstractTypeFactory<IndexEntity>.TryCreateInstance().FromModel(index, primaryKeyResolvingMap);
            var targetEntity = await _bulletJournalRepository.Indexes.FirstOrDefaultAsync(x => x.Id == index.Id);
            if (targetEntity != null)
            {
                targetEntity.UpdatedAt = DateTime.Now;
                sourceEntity.Patch(targetEntity);

                _bulletJournalRepository.Update(targetEntity);
                await _bulletJournalRepository.UnitOfWork.CommitAsync();
                primaryKeyResolvingMap.ResolvePrimaryKeys();
            }
        }

        public async Task DeleteIndex(string indexId)
        {
            var targetEntity = await _bulletJournalRepository.Indexes.FirstOrDefaultAsync(x => x.Id == indexId);
            if (targetEntity != null)
            {
                _bulletJournalRepository.Remove(targetEntity);
                await _bulletJournalRepository.UnitOfWork.CommitAsync();
            }
        }
    }
}
