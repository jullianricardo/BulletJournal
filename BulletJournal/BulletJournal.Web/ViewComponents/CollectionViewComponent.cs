using BulletJournal.Web.ViewModels.Collection;
using Microsoft.AspNetCore.Mvc;

namespace BulletJournal.Web.ViewComponents
{
    public class CollectionViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(BulletJournal.Models.Collection.Collection collection)
        {
            var viewModel = new CollectionViewModel
            {
                Collection = collection
            };

            return View(viewModel);
        }
    }
}
