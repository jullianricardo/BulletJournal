using BulletJournal.Core.Common;
using BulletJournal.Models.Collection;

namespace BulletJournal.Data.Model.Collection
{
    public class DailyLogEntity : CollectionEntity
    {
        public DateTime CurrentDay { get; set; }

        public override Models.Collection.Collection ToModel(Models.Collection.Collection collection)
        {
            var dailyLog = base.ToModel(collection) as DailyLog;
            dailyLog.CurrentDay = CurrentDay;

            return dailyLog;
        }

        public override DailyLogEntity FromModel(Models.Collection.Collection collection, PrimaryKeyResolvingMap primaryKeyResolvingMap)
        {
            var dailyLogEntity = base.FromModel(collection, primaryKeyResolvingMap) as DailyLogEntity;
            CurrentDay = dailyLogEntity.CurrentDay;

            return this;
        }
    }
}
