using BulletJournal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Core.Services
{
    public interface IJournalService
    {
        Task<Journal> GetJournalById(string id);

        Task SaveJournal(Journal journal);

        Task UpdateJournal(Journal journal);

        Task DeleteJournal(string journalId);
    }
}
