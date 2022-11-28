using BulletJournal.Core.Domain;
using BulletJournal.Data.Model;
using BulletJournal.Data.Model.Bullet;
using BulletJournal.Data.Model.Collection;
using BulletJournal.Models;

namespace BulletJournal.Data.Repositories
{
    public interface IBulletJournalRepository : IRepository
    {
        IQueryable<JournalEntity> Journals { get; }
        IQueryable<IndexEntity> Indexes { get; }
        IQueryable<PageEntity> Pages { get; }
        IQueryable<TopicEntity> Topics { get; }
        IQueryable<CollectionEntity> Collections { get; }
        IQueryable<BulletEntity> Bullets { get; }

        //Task<JournalEntity> GetJournalByIdAsync(string id);
    }
}
