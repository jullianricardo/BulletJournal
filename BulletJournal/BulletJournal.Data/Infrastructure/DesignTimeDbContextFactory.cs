﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Data.Infrastructure
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BulletJournalContext>
    {
        public BulletJournalContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<BulletJournalContext>();

            builder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BulletJournal;Data Source=LAPTOP-RRVRFLO5;Trust Server Certificate=True");

            return new BulletJournalContext(builder.Options);
        }
    }
}