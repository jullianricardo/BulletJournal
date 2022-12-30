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
            _journalManager.SetJournal(journal);
            var currentSpread = _journalManager.GetCurrentSpread();

            var viewModel = new JournalViewModel
            {
                Journal = journal,
                CurrentSpread = currentSpread
            };

            return View(viewModel);
        }
    }
}
