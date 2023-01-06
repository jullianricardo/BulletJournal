using BulletJournal.Models.Bullet;

namespace BulletJournal.Core.Services.Factories
{
    public interface IBulletFactory
    {
        Bullet CreateBullet(BulletType bulletType);
    }
}
