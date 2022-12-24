using BulletJournal.Core.Common;
using BulletJournal.Models.Bullet;

namespace BulletJournal.Data.Model.Bullet
{
    public class EventEntity : BulletEntity
    {
        public DateTime Date { get; set; }

        public TimeSpan Duration { get; set; }

        public override Models.Bullet.Bullet ToModel(Models.Bullet.Bullet bullet)
        {
            var newEvent = base.ToModel(bullet) as Event;
            newEvent.Date = Date;
            newEvent.Duration = Duration;

            return newEvent;
        }

        public override BulletEntity FromModel(Models.Bullet.Bullet bullet, PrimaryKeyResolvingMap primaryKeyResolvingMap)
        {
            var eventEntity = base.FromModel(bullet, primaryKeyResolvingMap) as EventEntity;
            Date = eventEntity.Date;
            Duration = eventEntity.Duration;

            return this;
        }
    }
}
