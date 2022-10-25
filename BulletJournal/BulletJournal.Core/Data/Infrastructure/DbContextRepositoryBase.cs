using BulletJournal.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

namespace BulletJournal.Core.Data.Infrastructure
{
    public abstract class DbContextRepositoryBase<TContext> : IRepository where TContext : DbContext
    {
        protected DbContextRepositoryBase(TContext dbContext, IUnitOfWork unitOfWork = null)
        {
            DbContext = dbContext;

            DbContext.ChangeTracker.CascadeDeleteTiming = CascadeTiming.OnSaveChanges;
            DbContext.ChangeTracker.DeleteOrphansTiming = CascadeTiming.OnSaveChanges;

            UnitOfWork = unitOfWork ?? new DbContextUnitOfWork(dbContext);

            var connectionTimeout = dbContext.Database.GetDbConnection().ConnectionTimeout;
            dbContext.Database.SetCommandTimeout(connectionTimeout);
        }

        public TContext DbContext { get; private set; }


        #region IRepository Members

        public IUnitOfWork UnitOfWork { get; private set; }

        public void Attach<T>(T item) where T : class
        {
            DbContext.Attach(item);
        }

        public void Add<T>(T item) where T : class
        {
            DbContext.Add(item);
        }

        public void Update<T>(T item) where T : class
        {
            DbContext.Update(item);
        }

        public void Remove<T>(T item) where T : class
        {
            DbContext.Remove(item);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && DbContext != null)
            {
                DbContext.Dispose();
                DbContext = null;
                UnitOfWork = null;
            }
        }

        #endregion
    }
}
