using BulletJournal.Core.Domain;
using BulletJournal.Data.Infrastructure;
using BulletJournal.Data.Model;
using BulletJournal.Data.Model.Bullet;
using BulletJournal.Data.Model.Collection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Data.Repositories
{
    public class BulletJournalRepository : DbContextRepositoryBase<BulletJournalContext>, IBulletJournalRepository
    {
        public BulletJournalRepository(BulletJournalContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<JournalEntity> Journals => DbContext.Set<JournalEntity>();
        public IQueryable<IndexEntity> Indexes => DbContext.Set<IndexEntity>();
        public IQueryable<PageEntity> Pages => DbContext.Set<PageEntity>();
        public IQueryable<TopicEntity> Topics => DbContext.Set<TopicEntity>();
        public IQueryable<CollectionEntity> Collections => DbContext.Set<CollectionEntity>();
        public IQueryable<BulletEntity> Bullets => DbContext.Set<BulletEntity>();
    }
}
