namespace BulletJournal.Web.Services.Interfaces
{
    public interface IBulletService
    {
        Task AddBullet(BulletJournal.Models.Bullet.Bullet bullet);
        Task EditBullet(BulletJournal.Models.Bullet.Bullet bullet);
    }
}
