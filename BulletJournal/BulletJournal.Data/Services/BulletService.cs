using BulletBullet.Core.Services;
using BulletJournal.Core.Repositories;
using BulletJournal.Models.Bullet;

namespace BulletJournal.Data.Services
{
    public class BulletService : IBulletService
    {
        private readonly IBulletRepository _bulletRepository;

        public BulletService(IBulletRepository bulletRepository)
        {
            _bulletRepository = bulletRepository;
        }

        public async System.Threading.Tasks.Task SaveBullet(Bullet bullet)
        {
            try
            {
                if (bullet.Order == 0)
                {
                    int lastBulletOrder = await _bulletRepository.GetLastBulletOrderInLog(bullet.LogId);
                    bullet.Order = lastBulletOrder + 1;
                }

                await _bulletRepository.SaveBullet(bullet);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async System.Threading.Tasks.Task UpdateBullet(Bullet bullet)
        {
            try
            {
                await _bulletRepository.UpdateBullet(bullet);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async System.Threading.Tasks.Task DeleteBullet(string bulletId)
        {
            try
            {
                await _bulletRepository.DeleteBullet(bulletId);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
