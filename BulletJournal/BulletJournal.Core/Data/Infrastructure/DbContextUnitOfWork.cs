using BulletJournal.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BulletJournal.Core.Data.Infrastructure
{
    public class DbContextUnitOfWork : IUnitOfWork
    {
        public DbContext DbContext { get; private set; }

        public DbContextUnitOfWork(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public int Commit()
        {
            return DbContext.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return DbContext.SaveChangesAsync();
        }
    }
}
