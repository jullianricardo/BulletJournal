using BulletJournal.Core.Common;
using BulletJournal.Core.Domain;
using BulletJournal.Models.Domain;
using System.Collections.ObjectModel;

namespace BulletJournal.Data.Model
{
    public class IndexEntity : Entity
    {
        #region Navigation Properties
        public ObservableCollection<TopicEntity> Topics { get; set; } = new NullCollection<TopicEntity>();

        public string? JournalId { get; set; }

        public JournalEntity? Journal { get; set; }

        #endregion

        public virtual Models.Index ToModel(Models.Index index)
        {
            if (index == null)
                throw new ArgumentNullException(nameof(index));

            index.Id = Id;

            return index;
        }

        public virtual IndexEntity FromModel(Models.Index index, PrimaryKeyResolvingMap primaryKeyResolvingMap)
        {
            if (index == null)
                throw new ArgumentNullException(nameof(index));

            primaryKeyResolvingMap.AddPair(index, this);

            Id = index.Id;

            return this;
        }
    }
}
