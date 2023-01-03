using BulletJournal.Core.Services.Managers;
using BulletJournal.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulletJournal.Web.Pages.Journal.Page
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IJournalService _journalService;
        private readonly IJournalManager _journalManager;

        public IndexModel(IJournalService journalService, IJournalManager journalManager)
        {
            _journalService = journalService;
            _journalManager = journalManager;
        }

        public async Task<IActionResult> OnGet(int pageNumber)
        {
            string journalId = HttpContext.Session.GetString("journalId");
            var journal = await _journalService.GetJournalById(journalId);

            if (journal == null)
                return BadRequest("Journal not found");

            _journalManager.SetJournal(journal);
            var page = _journalManager.FindPage(pageNumber);
            if (page == null)
            {
                return NotFound();
            }

            return RedirectToPage("/Journal/Index", new { pageId = page.Id });
        }
    }
}
