using BulletJournal.Data.Infrastructure;

namespace BulletJournal.Data.Repositories.Base
{
    public interface IBulletJournalRepository
    {
        public BulletJournalContext DbContext { get; }


        public void SaveChanges();
        public Task SaveChangesAsync();
    }
}
