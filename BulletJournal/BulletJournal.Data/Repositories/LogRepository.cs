using BulletJournal.Core.Repositories;
using BulletJournal.Data.EntityConverters.Interfaces;
using BulletJournal.Data.Infrastructure;
using BulletJournal.Data.Model.Bullet;
using BulletJournal.Data.Model.Collection;
using BulletJournal.Data.Repositories.Base;
using BulletJournal.Models.Bullet;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Data.Repositories
{
    public class LogRepository : BulletJournalRepository, ILogRepository
    {
        private readonly DbSet<LogEntity> _logs;
        private readonly ILogEntityConverter _logEntityConverter;

        public LogRepository(BulletJournalContext dbContext, ILogEntityConverter logEntityConverter) : base(dbContext)
        {
            _logs = dbContext.Logs;
            _logEntityConverter = logEntityConverter;
        }

        //public async System.Threading.Tasks.Task SaveBullet(Bullet bullet)
        //{
        //    var bulletEntity = _bulletEntityConverter.ConvertFromModelEntity(bullet);
        //    _bullets.Add(bulletEntity);
        //    await SaveChangesAsync();
        //}

        //public async System.Threading.Tasks.Task UpdateBullet(Bullet bullet)
        //{
        //    var bulletEntity = _bulletEntityConverter.ConvertFromModelEntity(bullet);
        //    var existingEntity = await _bullets.FindAsync(bullet.Id);
        //    if (existingEntity != null)
        //    {
        //        bulletEntity.Patch(existingEntity);
        //        _bullets.Update(existingEntity);

        //        await SaveChangesAsync();
        //    }
        //}

        //public async System.Threading.Tasks.Task DeleteBullet(string bulletId)
        //{
        //    var bulletEntity = await _bullets.FindAsync(bulletId);
        //    if (bulletEntity != null)
        //    {
        //        _bullets.Remove(bulletEntity);
        //        await SaveChangesAsync();
        //    }

        //}
    }
}
