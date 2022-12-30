﻿using BulletJournal.Models;
using BulletJournal.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BulletJournal.Web.ViewComponents
{
    public class JournalViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Journal journal)
        {
            var viewModel = new JournalViewModel
            {
                Journal = journal
            };

            return View(viewModel);
        }
    }
}
