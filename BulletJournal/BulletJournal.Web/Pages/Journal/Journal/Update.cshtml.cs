using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace BulletJournal.Web.Pages.Journal.Journal
{
    public class UpdateModel : PageModel
    {
        [BindProperty]
        public UpdateJournalViewModel Journal { get; set; }

        public void OnGet()
        {
        }
    }

    public class UpdateJournalViewModel
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Year { get; set; }
    }
}
