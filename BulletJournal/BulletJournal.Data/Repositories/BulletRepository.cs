using BulletJournal.Core.Repositories;
using BulletJournal.Data.EntityConverters.Interfaces;
using BulletJournal.Data.Infrastructure;
using BulletJournal.Data.Model.Bullet;
using BulletJournal.Data.Repositories.Base;
using BulletJournal.Models.Bullet;
using Microsoft.EntityFrameworkCore;

namespace BulletJournal.Data.Repositories
{
    public class BulletRepository : BulletJournalRepository, IBulletRepository
    {
        private readonly DbSet<BulletEntity> _bullets;
        private readonly IBulletEntityConverter _bulletEntityConverter;

        public BulletRepository(BulletJournalContext dbContext, IBulletEntityConverter bulletEntityConverter) : base(dbContext)
        {
            _bullets = dbContext.Bullets;
            _bulletEntityConverter = bulletEntityConverter;
        }

        public async System.Threading.Tasks.Task SaveBullet(Bullet bullet)
        {
            var bulletEntity = _bulletEntityConverter.ConvertFromModelEntity(bullet);
            _bullets.Add(bulletEntity);
            await SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task UpdateBullet(Bullet bullet)
        {
            var bulletEntity = _bulletEntityConverter.ConvertFromModelEntity(bullet);
            var existingEntity = await _bullets.FindAsync(bullet.Id);
            if (existingEntity != null)
            {
                bulletEntity.Patch(existingEntity);
                _bullets.Update(existingEntity);

                await SaveChangesAsync();
            }
        }

        public async System.Threading.Tasks.Task DeleteBullet(string bulletId)
        {
            var bulletEntity = await _bullets.FindAsync(bulletId);
            if (bulletEntity != null)
            {
                _bullets.Remove(bulletEntity);
                await SaveChangesAsync();
            }

        }

        public async Task<int> GetLastBulletOrderInLog(string logId)
        {
            var lastBulletInLog = await _bullets.Where(x => x.LogId == logId).OrderByDescending(x => x.Order).FirstOrDefaultAsync();
            int lastBulletOrder = lastBulletInLog?.Order ?? 0;
            return lastBulletOrder;
        }
    }
}
