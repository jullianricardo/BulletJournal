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
    public class JournalService : IJournalService
    {
        private readonly IBulletJournalRepository _bulletJournalRepository;

        public JournalService(IBulletJournalRepository bulletJournalRepository)
        {
            _bulletJournalRepository = bulletJournalRepository;
        }

        public async Task<Journal> GetJournalById(string id)
        {
            var journalEntity = await _bulletJournalRepository.Journals.FirstOrDefaultAsync(x => x.Id == id);
            var journal = journalEntity.ToModel(AbstractTypeFactory<Journal>.TryCreateInstance());
            return journal;
        }

        public async Task SaveJournal(Journal journal)
        {
            var primaryKeyResolvingMap = new PrimaryKeyResolvingMap();
            var journalEntity = AbstractTypeFactory<JournalEntity>.TryCreateInstance().FromModel(journal, primaryKeyResolvingMap);
            _bulletJournalRepository.Add(journalEntity);
            await _bulletJournalRepository.UnitOfWork.CommitAsync();
            primaryKeyResolvingMap.ResolvePrimaryKeys();
        }

        public async Task UpdateJournal(Journal journal)
        {
            var primaryKeyResolvingMap = new PrimaryKeyResolvingMap();

            var existingJournalEntity = await _bulletJournalRepository.Journals.FirstOrDefaultAsync(x => x.Id == journal.Id);
            var journalEntity = existingJournalEntity.FromModel(journal, primaryKeyResolvingMap);
            _bulletJournalRepository.Update(journalEntity);
            await _bulletJournalRepository.UnitOfWork.CommitAsync();
            primaryKeyResolvingMap.ResolvePrimaryKeys();
        }

        public Task DeleteJournal(string journalId) => throw new NotImplementedException();
    }
}
