using BulletJournal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Core.Data.Repositories
{
    public class JournalContext : BaseContext
    {
        public JournalContext(DbContextOptions<BaseContext> options) : base(options)
        {
        }

        public DbSet<Journal> Journals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Index>().Ignore(nameof(Models.Index.Topics));
            modelBuilder.Entity<Models.Collection.Collection>().Ignore(nameof(Models.Collection.Collection.Bullets));
        }
    }
}
