using BulletJournal.Data.Model;
using BulletJournal.Data.Model.Bullet;
using BulletJournal.Data.Model.Collection;
using Microsoft.EntityFrameworkCore;

namespace BulletJournal.Data.Infrastructure
{
    public class BulletJournalContext : BaseContext
    {

        public DbSet<JournalEntity> Journals { get; set; }
        public DbSet<IndexEntity> Indexes { get; set; }
        public DbSet<PageEntity> Pages { get; set; }
        public DbSet<CollectionPageEntity> CollectionPages { get; set; }
        public DbSet<TopicEntity> Topics { get; set; }
        public DbSet<CollectionEntity> Collections { get; set; }
        public DbSet<BulletEntity> Bullets { get; set; }

        public BulletJournalContext(DbContextOptions<BulletJournalContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BulletJournalContext).Assembly);
        }
    }
}
