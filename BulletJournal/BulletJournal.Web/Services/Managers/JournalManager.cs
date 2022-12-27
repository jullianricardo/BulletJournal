using BulletJournal.Core.Services;
using BulletJournal.Models;
using BulletJournal.Web.Services.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Web.Services.Managers
{
    public class JournalManager : IJournalManager
    {
        private readonly ISettingsService _settingsService;
        private List<Page> _pages;
        private Journal _journal;

        public JournalManager(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public Journal Journal
        {
            get
            {
                return _journal;
            }
            set
            {
                _pages = value.Pages ?? new List<Page>();
                _journal = value;
            }
        }

        public void BuildPageNumbers()
        {

        }

    }
}
