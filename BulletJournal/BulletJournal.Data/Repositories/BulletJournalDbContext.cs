using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Data.Repositories
{
    public class BulletJournalDbContext : DbContext
    {

        public BulletJournalDbContext(DbContextOptions<BulletJournalDbContext> options) : base(options)
        {
        }

        public BulletJournalDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BulletJournal;Data Source=LAPTOP-RRVRFLO5");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Index>().Ignore(nameof(Models.Index.Topics));
            modelBuilder.Entity<Models.Collection.Collection>().Ignore(nameof(Models.Collection.Collection.Bullets));

            base.OnModelCreating(modelBuilder);
        }
    }
}
