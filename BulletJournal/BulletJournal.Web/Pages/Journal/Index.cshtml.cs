using BulletJournal.Web.Services.Interfaces;
using BulletJournal.Data.Model.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace BulletJournal.Web.Pages.Journal
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly IJournalService _journalService;

        public IndexModel(UserManager<User> userManager, IJournalService journalService)
        {
            _userManager = userManager;
            _journalService = journalService;
        }

        [BindProperty]
        public BulletJournal.Models.Journal Journal { get; set; }

        public async Task OnGetAsync()
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            var ownerId = user.Id;
            Journal = await _journalService.GetOwnerDefaultJournal(ownerId);
        }
    }
}
