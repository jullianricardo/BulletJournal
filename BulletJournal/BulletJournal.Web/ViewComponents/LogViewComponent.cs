using BulletJournal.Models;
using BulletJournal.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BulletJournal.Web.ViewComponents
{
    public class LogViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Log log)
        {
            var viewModel = new LogViewModel
            {
                Log = log
            };

            return View(viewModel);
        }
    }
}
