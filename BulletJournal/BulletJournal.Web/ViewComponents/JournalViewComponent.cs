using BulletJournal.Core.Services.Managers;
using BulletJournal.Models;
using BulletJournal.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BulletJournal.Web.ViewComponents
{
    public class JournalViewComponent : ViewComponent
    {
        private readonly IJournalManager _journalManager;

        public JournalViewComponent(IJournalManager journalManager)
        {
            _journalManager = journalManager;
        }

        public IViewComponentResult Invoke(Journal journal)
        {
            if (journal == null)
                return View(new JournalViewModel());

            _journalManager.SetJournal(journal);
            var currentSpread = _journalManager.GetCurrentSpread();

            Page previousPage = null, nextPage = null;

            if (currentSpread != null)
            {
                int firstPageNumber = currentSpread.GetFirstPageNumber();
                int lastPageNumber = currentSpread.GetLastPageNumber();

                previousPage = _journalManager.FindPage(firstPageNumber - 1);
                nextPage = _journalManager.FindPage(lastPageNumber + 1);
            }

            var viewModel = new JournalViewModel
            {
                Journal = journal,
                CurrentSpread = currentSpread,
                PreviousPage = previousPage,
                NextPage = nextPage
            };

            return View(viewModel);
        }
    }
}
