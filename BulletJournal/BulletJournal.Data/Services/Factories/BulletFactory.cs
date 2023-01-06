using BulletJournal.Core.Services.Factories;
using BulletJournal.Models.Bullet;

namespace BulletJournal.Data.Services.Factories
{
    public class BulletFactory : IBulletFactory
    {
        public Bullet CreateBullet(BulletType bulletType)
        {
            return bulletType switch
            {
                BulletType.Task => new Models.Bullet.Task(),
                BulletType.Event => new Event(),
                BulletType.Note => new Note(),
                _ => null,
            };
        }
    }
}
