using BulletJournal.Models.Domain;

namespace BulletJournal.Data.Model
{
    public class TopicEntity : Entity
    {
        public string Title { get; set; }

        #region Navigation Properties

        public string IndexId { get; set; }

        public virtual IndexEntity Index { get; set; }

        public virtual string PageNumbers { get; set; }

        #endregion

        public virtual void Patch(TopicEntity target)
        {
            target.Title = Title;
            target.PageNumbers = PageNumbers;
            target.IndexId = IndexId;
        }
    }
}
