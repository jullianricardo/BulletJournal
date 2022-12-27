using BulletJournal.Data.Infrastructure;

namespace BulletJournal.Data.Repositories.Base
{
    public class BulletJournalRepository : IBulletJournalRepository
    {
        public BulletJournalRepository(BulletJournalContext dbContext)
        {
            DbContext = dbContext;
        }

        public BulletJournalContext DbContext { get; private set; }

        public virtual void SetDbContext(BulletJournalContext context)
        {
            DbContext = context;
        }

        public virtual void SaveChanges()
        {
            DbContext.SaveChanges();
        }

        public virtual async Task SaveChangesAsync()
        {

            await DbContext.SaveChangesAsync();
        }
    }
}
