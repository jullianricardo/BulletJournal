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
        public DbSet<TopicEntity> Topics { get; set; }
        public DbSet<CollectionEntity> Collections { get; set; }
        public DbSet<BulletEntity> Bullets { get; set; }

        public BulletJournalContext(DbContextOptions<BaseContext> options) : base(options)
        {
        }

        public BulletJournalContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<JournalEntity>(entity =>
            {
                entity.ToTable("Journal").HasKey(x => x.Id);
                entity.Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<IndexEntity>(entity =>
            {
                entity.ToTable("Index").HasKey(x => x.Id);
                entity.Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<TopicEntity>(entity =>
            {
                entity.ToTable("Topic").HasKey(x => x.Id);
                entity.Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<CollectionEntity>(entity =>
            {
                entity.ToTable("Collection").HasKey(x => x.Id);
                entity.Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<PageEntity>(entity =>
            {
                entity.ToTable("Page").HasKey(x => x.Id);
                entity.Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<BulletEntity>(entity =>
            {
                entity.ToTable("Bullet").HasKey(x => x.Id);
                entity.HasOne(m => m.Parent).WithMany().HasForeignKey(m => m.ParentId).OnDelete(DeleteBehavior.Restrict);
                entity.Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();
            });
        }
    }
}
