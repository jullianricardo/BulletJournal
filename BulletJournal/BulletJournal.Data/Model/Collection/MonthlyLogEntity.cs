using BulletJournal.Core.Common;
using BulletJournal.Core.Domain;
using BulletJournal.Models.Calendar;
using BulletJournal.Models.Collection;

namespace BulletJournal.Data.Model.Collection
{
    public class MonthlyLogEntity : CollectionEntity
    {
        public Month Month { get; set; }

        public virtual Calendar.CalendarEntity Calendar { get; set; }

        public override MonthlyLog ToModel(Models.Collection.Collection collection)
        {
            var monthlyLog = base.ToModel(collection) as MonthlyLog;

            monthlyLog.Month = Month;
            monthlyLog.Calendar = Calendar.ToModel(AbstractTypeFactory<Models.Calendar.Calendar>.TryCreateInstance());

            return monthlyLog;
        }

        public override MonthlyLogEntity FromModel(Models.Collection.Collection collection, PrimaryKeyResolvingMap primaryKeyResolvingMap)
        {
            var monthlyLogEntity = base.FromModel(collection, primaryKeyResolvingMap) as MonthlyLogEntity;

            Month = monthlyLogEntity.Month;
            Calendar = monthlyLogEntity.Calendar;

            return this;
        }
    }
}
