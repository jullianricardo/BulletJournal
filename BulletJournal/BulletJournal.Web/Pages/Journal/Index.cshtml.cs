using BulletJournal.Web.Services.Interfaces;
using BulletJournal.Data.Model.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using BulletJournal.Core.Services.Managers;
using BulletJournal.Models;

namespace BulletJournal.Web.Pages.Journal
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly IJournalService _journalService;
        private readonly IJournalManager _journalManager;

        public IndexModel(UserManager<User> userManager, IJournalService journalService, IJournalManager journalManager)
        {
            _userManager = userManager;
            _journalService = journalService;
            _journalManager = journalManager;
        }

        [BindProperty]
        public BulletJournal.Models.Journal Journal { get; set; }

        public async Task OnGetAsync(string pageId)
        {
            string journalId = HttpContext.Session.GetString("journalId");
            if (string.IsNullOrWhiteSpace(journalId))
            {
                var user = await _userManager.FindByEmailAsync(User.Identity.Name);
                var ownerId = user.Id;
                var journal = await _journalService.GetOwnerDefaultJournal(ownerId);
                Journal = journal;
            }
            else
            {
                Journal = await _journalService.GetJournalById(journalId);
            }

            if (Journal != null)
            {
                HttpContext.Session.SetString("journalId", Journal.Id);
                _journalManager.SetJournal(Journal);

                if (!string.IsNullOrWhiteSpace(pageId))
                {
                    _journalManager.SetCurrentPage(pageId);
                }
            }
        }
    }
}
