using BulletJournal.Models.Bullet;
using System.Threading.Tasks;

namespace BulletJournal.Core.Repositories
{
    public interface IBulletRepository
    {
        System.Threading.Tasks.Task SaveBullet(Bullet bullet);

        System.Threading.Tasks.Task UpdateBullet(Bullet bullet);

        System.Threading.Tasks.Task DeleteBullet(string bulletId);

        Task<int> GetLastBulletOrderInLog(string logId);
    }
}
