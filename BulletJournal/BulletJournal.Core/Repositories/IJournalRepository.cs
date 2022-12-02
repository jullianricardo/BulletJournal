using BulletJournal.Models;
using System.Threading.Tasks;

namespace BulletJournal.Core.Repositories
{
    public interface IJournalRepository
    {
        Task<Journal> GetJournalById(string id);

        Task SaveJournal(Journal journal);

        Task UpdateJournal(Journal journal);

        Task DeleteJournal(string journalId);
    }
}
