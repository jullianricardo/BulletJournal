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

            if (journalEntity == null)
                return null;

            var journal = journalEntity.ToModel(AbstractTypeFactory<Journal>.TryCreateInstance());
            return journal;
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
    }
}
