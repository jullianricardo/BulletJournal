using BulletJournal.Models;
using BulletJournal.Web.Services.Interfaces;

namespace BulletJournal.Web.Services
{
    public class PageService : BaseService, IPageService
    {
        private const string PAGES_BASE_URL = "pages";
        private const string PAGE_BASE_URL = "page/{0}?complete={1}";

        public PageService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor) : base(httpClientFactory, httpContextAccessor)
        {
        }

        public async Task<Page> GetPageById(string pageId, bool completePage = false)
        {
            string url = string.Format(PAGE_BASE_URL, pageId, completePage.ToString());
            var page = await GetFromEndpoint<Page>(url);
            return page;
        }
    }
}
