using BulletJournal.Core.Domain;
using BulletJournal.Models;

namespace BulletJournal.Data.Repositories
{
    public interface IBulletJournalRepository : IRepository
    {
        IQueryable<Journal> Journals { get; }
    }
}
