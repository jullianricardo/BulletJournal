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

        public override Models.Bullet.Task ToModel(Models.Bullet.Bullet bullet)
        {
            var task = base.ToModel(bullet) as Models.Bullet.Task;

            task.Status = Status;
            task.IsActive = IsActive;

            return task;
        }

        public override TaskEntity FromModel(Models.Bullet.Bullet bullet, PrimaryKeyResolvingMap primaryKeyResolvingMap)
        {
            var taskEntity = base.FromModel(bullet, primaryKeyResolvingMap) as TaskEntity;

            Status = taskEntity.Status;
            IsActive = taskEntity.IsActive;

            return this;
        }
    }
}
