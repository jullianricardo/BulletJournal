using BulletJournal.Models.Bullet;
using BulletJournal.Web.Services.Interfaces;

namespace BulletJournal.Web.Services
{
    public class BulletService : BaseService, IBulletService
    {
        private const string BULLETS_BASE_URL = "bullets";
        private const string BULLET_BASE_URL = "bullet";

        public BulletService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor) : base(httpClientFactory, httpContextAccessor)
        {
        }

        public async System.Threading.Tasks.Task AddBullet(Bullet bullet)
        {
            await PostToEndpoint(BULLET_BASE_URL, bullet);
        }

        public async System.Threading.Tasks.Task EditBullet(Bullet bullet)
        {
            await PutInEndpoint(BULLET_BASE_URL, bullet);
        }
    }
}
