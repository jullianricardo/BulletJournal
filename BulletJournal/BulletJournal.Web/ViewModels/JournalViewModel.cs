using BulletJournal.Models;

namespace BulletJournal.Web.ViewModels
{
    public class JournalViewModel
    {
        public Journal Journal { get; set; }

        public Page PreviousPage { get; set; }

        public Page NextPage { get; set; }

        public Spread CurrentSpread { get; set; }
    }
}
