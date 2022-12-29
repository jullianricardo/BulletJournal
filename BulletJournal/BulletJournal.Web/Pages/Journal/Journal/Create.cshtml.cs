using BulletJournal.Data.Model.Identity;
using BulletJournal.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace BulletJournal.Web.Pages.Journal.Journal
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly IJournalService _journalService;

        public CreateModel(UserManager<User> userManager, IJournalService journalService)
        {
            _userManager = userManager;
            _journalService = journalService;
        }

        [BindProperty]
        public CreateJournalViewModel Journal { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);

            var journal = new BulletJournal.Models.Journal
            {
                Name = Journal.Name,
                Description = Journal.Description,
                Year = Journal.Year,
                IsDefault = true,
                OwnerId = user.Id,
            };

            await _journalService.CreateJournal(journal);

            return RedirectToPage("/Journal/Index");
        }
    }

    public class CreateJournalViewModel
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Year { get; set; }
    }
}
