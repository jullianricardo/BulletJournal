using BulletJournal.Models.Bullet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletBullet.Core.Services
{
    public interface IBulletService
    {
        System.Threading.Tasks.Task SaveBullet(Bullet bullet);

        System.Threading.Tasks.Task UpdateBullet(Bullet bullet);

        System.Threading.Tasks.Task DeleteBullet(string bulletId);
    }
}
