using BulletJournal.Core.Common;
using BulletJournal.Core.Domain;
using BulletJournal.Data.Model.Collection;
using BulletJournal.Models;
using BulletJournal.Models.Domain;
using System.Collections.ObjectModel;

namespace BulletJournal.Data.Model
{
    public class PageEntity : Entity
    {
        public int Number { get; set; }
        public string Title { get; set; }


        #region NavigationProperties

        public string JournalId { get; set; }

        public virtual JournalEntity Journal { get; set; }

        public virtual ObservableCollection<CollectionEntity> Collections { get; set; } = new NullCollection<CollectionEntity>();

        #endregion    


        public virtual Page ToModel(Page page)
        {
            if (page == null)
                throw new ArgumentNullException(nameof(page));

            page.Id = Id;
            page.Number = Number;
            page.Title = Title;

            return page;
        }

        public virtual PageEntity FromModel(Page page, PrimaryKeyResolvingMap primaryKeyResolvingMap)
        {
            if (page == null)
                throw new ArgumentNullException(nameof(page));

            primaryKeyResolvingMap.AddPair(page, this);

            Id = page.Id;
            Number = page.Number;
            Title = page.Title;

            return this;
        }
    }
}
