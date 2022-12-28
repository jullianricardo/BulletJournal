using BulletJournal.Core.Common;
using BulletJournal.Core.Domain;
using BulletJournal.Core.Extensions;
using BulletJournal.Models.Domain;
using System.Collections.ObjectModel;

namespace BulletJournal.Data.Model
{
    public class IndexEntity : Entity
    {
        #region Navigation Properties
        public ObservableCollection<TopicEntity> Topics { get; set; } = new NullCollection<TopicEntity>();

        public string JournalId { get; set; }

        public JournalEntity Journal { get; set; }

        #endregion      

        public virtual void Patch(IndexEntity target)
        {
            target.JournalId = JournalId;

            if (!Topics.IsNullCollection())
            {
                var comparer = AnonymousComparer.Create((TopicEntity entity) => entity.Id);
                Topics.Patch(target.Topics, comparer, (sourceEntity, targetEntity) => targetEntity.Id = sourceEntity.Id);
            }
        }
    }
}
