using BulletJournal.Data.Model;
using BulletJournal.Data.Model.Collection;
using BulletJournal.Models;
using Microsoft.EntityFrameworkCore;

namespace BulletJournal.Data.Repositories
{
    public class JournalContext : BaseContext
    {
        public JournalContext(DbContextOptions<BaseContext> options) : base(options)
        {
        }

        public DbSet<JournalEntity>? Journals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JournalEntity>()
                .ToTable("Journal")
                .HasKey(x => x.Id);


            modelBuilder.Entity<IndexEntity>()
                .ToTable("Index")
                .HasKey(x => x.Id);


            modelBuilder.Entity<CollectionEntity>()
                .ToTable("Collection")
                .Ignore(nameof(Models.Collection.Collection.Bullets))
                .HasKey(x => x.Id);
        }
    }
}
