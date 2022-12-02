using BulletJournal.Core.Domain;
using BulletJournal.Core.Repositories;
using BulletJournal.Data.Infrastructure;
using BulletJournal.Data.Model;
using BulletJournal.Data.Repositories.Base;
using BulletJournal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Data.Repositories
{
    public class IndexRepository : BulletJournalRepository, IIndexRepository
    {
        private readonly DbSet<IndexEntity> _indexes;

        public IndexRepository(BulletJournalContext dbContext) : base(dbContext)
        {
            _indexes = dbContext.Indexes;
        }

        public async Task<Models.Index> GetIndexById(string id)
        {
            var indexEntity = await _indexes.FindAsync(id);
            if (indexEntity == null)
                return null;

            var index = indexEntity.ToModel(AbstractTypeFactory<Models.Index>.TryCreateInstance());
            return index;
        }

        public async Task<Models.Index> GetIndexByJournalId(string journalId)
        {
            var indexEntity = await _indexes.FirstOrDefaultAsync(x => x.JournalId == journalId);
            if (indexEntity == null)
                return null;

            var index = indexEntity.ToModel(AbstractTypeFactory<Models.Index>.TryCreateInstance());
            return index;
        }

        public async Task CreateIndex(Models.Index index)
        {
            var indexEntity = AbstractTypeFactory<IndexEntity>.TryCreateInstance().FromModel(index, new Core.Common.PrimaryKeyResolvingMap());
            indexEntity.CreatedAt = DateTime.Now;
            _indexes.Add(indexEntity);
            await SaveChangesAsync();

        }

        public async Task UpdateIndex(Models.Index index)
        {
            var indexEntity = AbstractTypeFactory<IndexEntity>.TryCreateInstance().FromModel(index, new Core.Common.PrimaryKeyResolvingMap());
            var existingEntity = await _indexes.FindAsync(index.Id);
            if (existingEntity != null)
            {
                indexEntity.Patch(existingEntity);
                existingEntity.UpdatedAt = DateTime.Now;
                _indexes.Update(existingEntity);

                await SaveChangesAsync();
            }
        }

        public async Task DeleteIndex(string indexId)
        {
            var indexEntity = await _indexes.FindAsync(indexId);
            if (indexEntity != null)
            {
                _indexes.Remove(indexEntity);
                await SaveChangesAsync();
            }
        }
    }
}
