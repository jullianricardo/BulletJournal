using BulletJournal.Models;
using BulletJournal.Models.Collection;

namespace BulletJournal.Core.Services.Managers
{
    public interface IPageManager
    {
        Page Page { get; }

        void SetPage(Page page);

        void AddCollection(Collection collection);

        int GetPageFreeSize();

        bool CollectionFitsInPage(Collection collection);
    }
}
