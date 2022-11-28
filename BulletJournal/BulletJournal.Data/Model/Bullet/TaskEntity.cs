using BulletJournal.Core.Common;
using BulletJournal.Models.Bullet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Data.Model.Bullet
{
    public class TaskEntity : BulletEntity
    {
        public Status Status { get; set; }

        public bool IsActive { get; set; }

        public override Models.Bullet.Task ToModel(Models.Bullet.Bullet? bullet)
        {
            var task = base.ToModel(bullet) as Models.Bullet.Task;

            task.Status = Status;
            task.IsActive = IsActive;

            return task;
        }

        public override TaskEntity FromModel(Models.Bullet.Bullet? bullet, PrimaryKeyResolvingMap primaryKeyResolvingMap)
        {
            var taskEntity = base.FromModel(bullet, primaryKeyResolvingMap) as TaskEntity;

            Status = taskEntity.Status;
            IsActive = taskEntity.IsActive;

            return this;
        }
    }
}
