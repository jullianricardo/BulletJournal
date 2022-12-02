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
    public class JournalRepository : BulletJournalRepository, IJournalRepository
    {
        private readonly DbSet<JournalEntity> _journals;

        public JournalRepository(BulletJournalContext dbContext) : base(dbContext)
        {
            _journals = dbContext.Journals;
        }

        public async Task<Journal> GetJournalById(string id)
        {
            var journalEntity = await _journals.FindAsync(id);
            if (journalEntity == null)
                return null;

            var journal = journalEntity.ToModel(AbstractTypeFactory<Journal>.TryCreateInstance());
            return journal;
        }

        public async Task SaveJournal(Journal journal)
        {
            var journalEntity = AbstractTypeFactory<JournalEntity>.TryCreateInstance().FromModel(journal, new Core.Common.PrimaryKeyResolvingMap());
            journalEntity.CreatedAt = DateTime.Now;
            _journals.Add(journalEntity);
            await SaveChangesAsync();

        }

        public async Task UpdateJournal(Journal journal)
        {
            var journalEntity = AbstractTypeFactory<JournalEntity>.TryCreateInstance().FromModel(journal, new Core.Common.PrimaryKeyResolvingMap());
            var existingEntity = await _journals.FindAsync(journal.Id);
            if (existingEntity != null)
            {
                journalEntity.Patch(existingEntity);
                existingEntity.UpdatedAt = DateTime.Now;
                _journals.Update(existingEntity);

                await SaveChangesAsync();
            }
        }

        public async Task DeleteJournal(string journalId)
        {
            var journalEntity = await _journals.FindAsync(journalId);
            if (journalEntity != null)
            {
                _journals.Remove(journalEntity);
                await SaveChangesAsync();
            }
        }
    }
}
