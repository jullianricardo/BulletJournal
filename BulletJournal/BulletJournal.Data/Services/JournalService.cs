using BulletJournal.Core.Common;
using BulletJournal.Core.Domain;
using BulletJournal.Core.Repositories;
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
        private readonly IJournalRepository _journalRepository;

        public JournalService(IJournalRepository journalRepository)
        {
            _journalRepository = journalRepository;
        }

        public async Task<Journal> GetJournalById(string id)
        {
            var journal = await _journalRepository.GetJournalById(id);
            return journal;
        }

        public async Task SaveJournal(Journal journal)
        {
            await _journalRepository.SaveJournal(journal);
        }

        public async Task UpdateJournal(Journal journal)
        {
            await _journalRepository.UpdateJournal(journal);
        }

        public async Task DeleteJournal(string journalId)
        {
            await _journalRepository.DeleteJournal(journalId);
        }
    }
}
