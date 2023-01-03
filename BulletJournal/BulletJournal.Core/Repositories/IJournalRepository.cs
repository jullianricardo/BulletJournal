using BulletJournal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BulletJournal.Core.Repositories
{
    public interface IJournalRepository
    {
        Task<Journal> GetJournalById(string id);

        Task SaveJournal(Journal journal);

        Task UpdateJournal(Journal journal);

        Task DeleteJournal(string journalId);

        Task<Journal> GetOwnerDefaultJournal(string ownerId);

        Task<List<Journal>> GetJournalsByOwner(string ownerId);
    }
}
