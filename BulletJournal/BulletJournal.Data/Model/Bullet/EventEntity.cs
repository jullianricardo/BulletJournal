using BulletJournal.Models.Bullet;

namespace BulletJournal.Data.Model.Bullet
{
    public class EventEntity : BulletEntity
    {
        public override BulletType Type
        {
            get { return BulletType.Event; }
            set { }
        }

        public DateTime Date { get; set; }

        public TimeSpan Duration { get; set; }
    }
}
