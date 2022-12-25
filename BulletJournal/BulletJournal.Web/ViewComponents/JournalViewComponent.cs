using BulletJournal.Models;
using BulletJournal.Web.Services.Interfaces;
using BulletJournal.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Web.ViewComponents
{
    public class JournalViewComponent : ViewComponent
    {
        private readonly IJournalService _journalService;

        public JournalViewComponent(IJournalService journalService)
        {
            _journalService = journalService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Journal journal)
        {
            var viewModel = new JournalViewModel
            {
                Journal = journal
            };

            return View(viewModel);
        }
    }
}
