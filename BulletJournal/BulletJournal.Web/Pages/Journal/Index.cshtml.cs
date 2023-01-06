using BulletJournal.Web.Services.Interfaces;
using BulletJournal.Data.Model.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using BulletJournal.Core.Services.Managers;
using BulletJournal.Models;
using System.ComponentModel.DataAnnotations;
using BulletJournal.Core.Services.Factories;
using BulletJournal.Web.ViewComponents;

namespace BulletJournal.Web.Pages.Journal
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly IJournalService _journalService;
        private readonly IJournalManager _journalManager;
        private readonly IBulletFactory _bulletFactory;

        public IndexModel(UserManager<User> userManager, IJournalService journalService, IJournalManager journalManager, IBulletFactory bulletFactory)
        {
            _userManager = userManager;
            _journalService = journalService;
            _journalManager = journalManager;
            _bulletFactory = bulletFactory;
        }

        [BindProperty]
        public BulletJournal.Models.Journal Journal { get; set; }

        [BindProperty]
        public AddBulletViewModel AddBulletViewModel { get; set; }

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

        public async Task<IActionResult> OnPostAsync()
        {
            var bullet = _bulletFactory.CreateBullet(AddBulletViewModel.BulletType);
            bullet.Description = AddBulletViewModel.Description;

            return ViewComponent(typeof(BulletViewComponent), new { bullet = bullet });
        }
    }

    public class AddBulletViewModel
    {
        [Required]
        public string LogId { get; set; }

        [Required]
        public BulletJournal.Models.Bullet.BulletType BulletType { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
