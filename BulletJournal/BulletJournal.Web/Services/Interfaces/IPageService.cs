using BulletJournal.Models;

namespace BulletJournal.Web.Services.Interfaces
{
    public interface IPageService
    {
        Task<Page> GetPageById(string pageId, bool completePage = false);
    }
}
