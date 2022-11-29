using BulletJournal.Data.Model;
using BulletJournal.Data.Model.Bullet;
using BulletJournal.Data.Model.Collection;
using BulletJournal.Models;
using BulletJournal.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BulletJournal.Data.Repositories
{
    public class BulletJournalContext : BaseContext
    {
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
                entity.Property(m => m.CreatedAt).HasComputedColumnSql("GETDATE()").ValueGeneratedOnAdd();
                entity.Property(m => m.UpdatedAt).HasComputedColumnSql("GETDATE()").ValueGeneratedOnUpdate();
            });

            modelBuilder.Entity<IndexEntity>(entity =>
            {
                entity.ToTable("Index").HasKey(x => x.Id);
                entity.Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();
                entity.Property(m => m.CreatedAt).ValueGeneratedOnAdd();
                entity.Property(m => m.UpdatedAt).ValueGeneratedOnUpdate();
            });

            modelBuilder.Entity<TopicEntity>(entity =>
            {
                entity.ToTable("Topic").HasKey(x => x.Id);
                entity.Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();
                entity.Property(m => m.CreatedAt).ValueGeneratedOnAdd();
                entity.Property(m => m.UpdatedAt).ValueGeneratedOnUpdate();
            });

            modelBuilder.Entity<CollectionEntity>(entity =>
            {
                entity.ToTable("Collection").HasKey(x => x.Id);
                entity.Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();
                entity.Property(m => m.CreatedAt).ValueGeneratedOnAdd();
                entity.Property(m => m.UpdatedAt).ValueGeneratedOnUpdate();
            });

            modelBuilder.Entity<PageEntity>(entity =>
            {
                entity.ToTable("Page").HasKey(x => x.Id);
                entity.Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();
                entity.Property(m => m.CreatedAt).ValueGeneratedOnAdd();
                entity.Property(m => m.UpdatedAt).ValueGeneratedOnUpdate();
            });

            modelBuilder.Entity<BulletEntity>(entity =>
            {
                entity.ToTable("Bullet").HasKey(x => x.Id);
                entity.HasOne(m => m.Parent).WithMany().HasForeignKey(m => m.ParentId).OnDelete(DeleteBehavior.Restrict);
                entity.Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();
                entity.Property(m => m.CreatedAt).HasComputedColumnSql("GETDATE()").ValueGeneratedOnAdd();
                entity.Property(m => m.UpdatedAt).HasComputedColumnSql("GETDATE()").ValueGeneratedOnUpdate();
            });

            //modelBuilder.Entity<JournalEntity>().ToTable("Journal").HasKey(x => x.Id);
            //modelBuilder.Entity<JournalEntity>().Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();

            //modelBuilder.Entity<IndexEntity>().ToTable("Index").HasKey(x => x.Id);
            //modelBuilder.Entity<IndexEntity>().Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();

            //modelBuilder.Entity<TopicEntity>().ToTable("Topic").HasKey(x => x.Id);
            //modelBuilder.Entity<TopicEntity>().Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();

            //modelBuilder.Entity<CollectionEntity>().ToTable("Collection").HasKey(x => x.Id);
            //modelBuilder.Entity<CollectionEntity>().Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();

            //modelBuilder.Entity<PageEntity>().ToTable("Page").HasKey(x => x.Id);
            //modelBuilder.Entity<PageEntity>().Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();

            //modelBuilder.Entity<BulletEntity>().ToTable("Bullet").HasKey(x => x.Id);
            //modelBuilder.Entity<BulletEntity>().Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();
            //modelBuilder.Entity<BulletEntity>().HasOne(m => m.Parent).WithMany().HasForeignKey(m => m.ParentId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
