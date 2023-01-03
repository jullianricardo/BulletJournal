using BulletJournal.Core.Repositories;
using BulletJournal.Data.EntityConverters.Interfaces;
using BulletJournal.Data.Infrastructure;
using BulletJournal.Data.Model;
using BulletJournal.Data.Repositories.Base;
using BulletJournal.Models;
using Microsoft.EntityFrameworkCore;

namespace BulletJournal.Data.Repositories
{
    public class JournalRepository : BulletJournalRepository, IJournalRepository
    {
        private readonly DbSet<JournalEntity> _journals;
        private readonly IJournalEntityConverter _journalEntityConverter;

        public JournalRepository(BulletJournalContext dbContext, IJournalEntityConverter journalEntityConverter) : base(dbContext)
        {
            _journals = dbContext.Journals;
            _journalEntityConverter = journalEntityConverter;
        }

        public IQueryable<JournalEntity> CompleteJournal
        {
            get
            {
                var completeJournal = _journals
                        .Include(x => x.Index)
                        .Include(x => x.Pages)
                        .ThenInclude(x => x.CollectionPages)
                        .ThenInclude(x => x.Collection)
                        .ThenInclude(x => x.Logs)
                        .ThenInclude(x => x.Bullets);

                return completeJournal;
            }
        }

        public async Task<Journal> GetJournalById(string id)
        {
            var journalEntity = await CompleteJournal.FirstOrDefaultAsync(x => x.Id == id);
            if (journalEntity == null)
                return null;

            var journal = _journalEntityConverter.ConvertFromDatabaseEntity(journalEntity);
            return journal;
        }

        public async Task SaveJournal(Journal journal)
        {
            try
            {
                var journalEntity = _journalEntityConverter.ConvertFromModelEntity(journal);
                _journals.Add(journalEntity);
                await SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task UpdateJournal(Journal journal)
        {
            var journalEntity = _journalEntityConverter.ConvertFromModelEntity(journal);

            var existingEntity = await _journals.FindAsync(journal.Id);
            if (existingEntity != null)
            {
                journalEntity.Patch(existingEntity);
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

        public async Task<Journal> GetOwnerDefaultJournal(string ownerId)
        {
            try
            {
                var journalEntity = await CompleteJournal.FirstOrDefaultAsync(x => x.OwnerId == ownerId && x.IsDefault);

                if (journalEntity == null)
                    return null;

                var journal = _journalEntityConverter.ConvertFromDatabaseEntity(journalEntity);
                return journal;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
