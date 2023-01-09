using BulletBullet.Core.Services;
using BulletJournal.Models.Bullet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BulletJournal.API.Controllers
{
    [ApiController]
    [Route("Bullet")]
    [Authorize]
    public class BulletController : ControllerBase
    {
        private readonly IBulletService _bulletService;

        public BulletController(IBulletService journalService)
        {
            _bulletService = journalService;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Bullet bullet)
        {
            await _bulletService.SaveBullet(bullet);
            return Ok(bullet);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Bullet bullet)
        {
            await _bulletService.UpdateBullet(bullet);
            return Ok(bullet);
        }
    }
}
