using BulletJournal.Data.Model;
using BulletJournal.Data.Model.Bullet;
using BulletJournal.Data.Model.Calendar;
using BulletJournal.Data.Model.Collection;
using BulletJournal.Models.Bullet;
using BulletJournal.Models.Domain;
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

            modelBuilder.Entity<DailyLogEntity>();
            modelBuilder.Entity<MonthlyLogEntity>();
            modelBuilder.Entity<FutureLogEntity>();

            modelBuilder.Entity<CollectionEntity>(entity =>
            {
                entity.ToTable("Collection").HasKey(x => x.Id);
                entity.Property(x => x.Order).IsRequired().HasDefaultValue(1);
                entity.HasIndex(x => new { x.JournalId, x.Order }).IsUnique();
                entity.HasDiscriminator(x => x.Type)
                    .HasValue<DailyLogEntity>(Models.Collection.CollectionType.DailyLog)
                    .HasValue<MonthlyLogEntity>(Models.Collection.CollectionType.MonthlyLog)
                    .HasValue<FutureLogEntity>(Models.Collection.CollectionType.FutureLog)
                    .IsComplete(false);

                entity.Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<PageEntity>(entity =>
            {
                entity.ToTable("Page").HasKey(x => x.Id);
                entity.Property(x => x.Number).IsRequired().HasDefaultValue(1);
                entity.HasIndex(x => new { x.JournalId, x.Number }).IsUnique();
                entity.Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<CollectionPageEntity>(entity =>
            {
                entity.ToTable("CollectionPage").HasKey(x => x.Id);
                entity.Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<LogEntity>(entity =>
            {
                entity.ToTable("Log").HasKey(x => x.Id);
                entity.Property(x => x.Order).IsRequired().HasDefaultValue(1);
                entity.HasIndex(x => new { x.CollectionId, x.Order }).IsUnique();
                entity.Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<BulletEntity>(entity =>
            {
                entity.ToTable("Bullet").HasKey(x => x.Id);
                entity.Property(x => x.Order).IsRequired().HasDefaultValue(1);
                entity.HasIndex(x => new { x.LogId, x.Order }).IsUnique();
                entity.HasDiscriminator(x => x.Type)
                    .HasValue<TaskEntity>(BulletType.Task)
                    .HasValue<NoteEntity>(BulletType.Note)
                    .HasValue<EventEntity>(BulletType.Event);

                entity.HasOne(m => m.Parent).WithMany().HasForeignKey(m => m.ParentId).OnDelete(DeleteBehavior.Restrict);
                entity.Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<TaskEntity>();
            modelBuilder.Entity<NoteEntity>();
            modelBuilder.Entity<EventEntity>();

            modelBuilder.Entity<CalendarEntity>().ToTable("Calendar")
                .Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();

            modelBuilder.Entity<HolidayEntity>().ToTable("Holiday")
                .Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();

            modelBuilder.Entity<FutureLogMonthEntity>().ToTable("FutureLogMonth")
                .Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();

            modelBuilder.Entity<DayEntity>().ToTable("Day")
                .Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();
        }
    }
}
