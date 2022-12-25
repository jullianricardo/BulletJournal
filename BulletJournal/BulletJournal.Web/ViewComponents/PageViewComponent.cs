using BulletJournal.Models;
using BulletJournal.Web.Models;
using BulletJournal.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BulletJournal.Web.ViewComponents
{
    public class PageViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Page page, PagePosition pagePosition)
        {
            var pageViewModel = new PageViewModel
            {
                Page = page,
                PagePosition = pagePosition
            };

            return View(pageViewModel);
        }
    }
}
