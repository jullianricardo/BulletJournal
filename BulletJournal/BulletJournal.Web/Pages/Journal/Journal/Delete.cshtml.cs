using BulletJournal.Data.Model.Identity;
using BulletJournal.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BulletJournal.Web.Pages.Journal.Journal
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly IJournalService _journalService;

        public DeleteModel(UserManager<User> userManager, IJournalService journalService)
        {
            _userManager = userManager;
            _journalService = journalService;
            ViewModel = new DeleteViewModel();
        }

        [BindProperty]
        public DeleteViewModel ViewModel { get; set; }

        public async Task OnGet()
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            var ownerId = user.Id;

            var userJournals = await _journalService.GetJournalsByOwner(ownerId);

            ViewModel.UserJournals = userJournals.Select(x => new SelectListItem { Text = x.Name, Value = x.Id }).ToList();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            await _journalService.DeleteJournal(ViewModel.SelectedJournalId);

            string sessionJournalId = HttpContext.Session.GetString("journalId");
            if (!string.IsNullOrWhiteSpace(sessionJournalId) && sessionJournalId == ViewModel.SelectedJournalId)
                HttpContext.Session.Remove("journalId");

            return RedirectToPage("/Journal/Index");
        }
    }

    public class DeleteViewModel
    {
        public List<SelectListItem> UserJournals { get; set; }

        [Required(ErrorMessage = "É necessário selecionar um diário")]
        public string SelectedJournalId { get; set; }
    }
}
