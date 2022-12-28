using BulletJournal.Data.Model.Identity;
using BulletJournal.Models.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BulletJournal.Data.Infrastructure
{
    public class BaseContext : IdentityDbContext<User>
    {
        public BaseContext(DbContextOptions options) : base(options)
        {
        }

        public override int SaveChanges()
        {
            var now = DateTime.UtcNow;

            foreach (var changedEntity in ChangeTracker.Entries())
            {
                if (changedEntity.Entity is Entity entity)
                {
                    switch (changedEntity.State)
                    {
                        case EntityState.Added:
                            entity.CreatedAt = now;
                            break;
                        case EntityState.Modified:
                            Entry(entity).Property(x => x.CreatedAt).IsModified = false;
                            entity.UpdatedAt = now;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var now = DateTime.UtcNow;

            foreach (var changedEntity in ChangeTracker.Entries())
            {
                if (changedEntity.Entity is Entity entity)
                {
                    switch (changedEntity.State)
                    {
                        case EntityState.Added:
                            entity.CreatedAt = now;
                            break;
                        case EntityState.Modified:
                            Entry(entity).Property(x => x.CreatedAt).IsModified = false;
                            entity.UpdatedAt = now;
                            break;
                    }
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
