using BulletJournal.Core.Common;
using BulletJournal.Models;
using BulletJournal.Models.Domain;

namespace BulletJournal.Data.Model
{
    public class TopicEntity : Entity
    {
        public string? Title { get; set; }

        #region Navigation Properties

        public string? IndexId { get; set; }

        public virtual IndexEntity? Index { get; set; }

        public virtual string? PageNumbers { get; set; }

        #endregion

        public virtual Topic ToModel(Topic topic)
        {
            if (topic == null)
            { throw new ArgumentNullException(nameof(topic)); }

            topic.Id = Id;
            topic.Title = Title;
            topic.PageNumbers = PageNumbers.Split(';').ToList();

            return topic;
        }

        public virtual TopicEntity FromModel(Topic topic, PrimaryKeyResolvingMap primaryKeyResolvingMap)
        {
            if (topic == null)
            { throw new ArgumentNullException(nameof(topic)); }

            primaryKeyResolvingMap.AddPair(topic, this);

            Id = topic.Id;
            Title = topic.Title;

            if (topic.PageNumbers != null)
                PageNumbers = string.Join(';', topic.PageNumbers);

            return this;
        }
    }
}
