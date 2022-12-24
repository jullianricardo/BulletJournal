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

        public virtual Models.Index ToModel(Models.Index index)
        {
            if (index == null)
                throw new ArgumentNullException(nameof(index));

            index.Id = Id;
            index.JournalId = JournalId;
            index.CreatedAt = CreatedAt;
            index.UpdatedAt = UpdatedAt;

            return index;
        }

        public virtual IndexEntity FromModel(Models.Index index, PrimaryKeyResolvingMap primaryKeyResolvingMap)
        {
            if (index == null)
                throw new ArgumentNullException(nameof(index));

            primaryKeyResolvingMap.AddPair(index, this);

            Id = index.Id;
            JournalId = index.JournalId;
            CreatedAt = index.CreatedAt;
            UpdatedAt = index.UpdatedAt;

            return this;
        }

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
