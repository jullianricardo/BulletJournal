using BulletJournal.Core.Common;
using BulletJournal.Models.Bullet;

namespace BulletJournal.Data.Model.Bullet
{
    public class TaskEntity : BulletEntity
    {
        public override BulletType Type
        {
            get { return BulletType.Task; }
            set { }
        }

        public Status Status { get; set; }

        public bool IsActive { get; set; }
    }
}
