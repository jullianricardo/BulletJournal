using BulletJournal.Models.Bullet;
using BulletJournal.Web.ViewModels.Bullet;
using Microsoft.AspNetCore.Mvc;

namespace BulletJournal.Web.ViewComponents
{
    public class BulletViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Bullet bullet)
        {
            var viewModel = new BulletViewModel
            {
                Bullet = bullet
            };

            return View(viewModel);
        }
    }
}
