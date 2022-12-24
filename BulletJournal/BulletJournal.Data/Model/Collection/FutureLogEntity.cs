using BulletJournal.Core.Common;
using BulletJournal.Core.Domain;
using BulletJournal.Models.Calendar;
using BulletJournal.Models.Collection;
using BulletJournal.Models.Domain;
using System.Collections.ObjectModel;

namespace BulletJournal.Data.Model.Collection
{
    public class FutureLogEntity : CollectionEntity
    {

        public int Year { get; set; }

        #region Navigation Properties

        public ObservableCollection<FutureLogMonthEntity> Months { get; set; } = new NullCollection<FutureLogMonthEntity>();

        #endregion

        public override FutureLog ToModel(Models.Collection.Collection collection)
        {
            var futureLog = base.ToModel(collection) as FutureLog;

            futureLog.Year = Year;
            futureLog.Months = Months.Select(x => x.ToModel(AbstractTypeFactory<FutureLogMonth>.TryCreateInstance())).ToList();

            return futureLog;
        }

        public override FutureLogEntity FromModel(Models.Collection.Collection collection, PrimaryKeyResolvingMap primaryKeyResolvingMap)
        {
            var futureLogEntity = base.FromModel(collection, primaryKeyResolvingMap) as FutureLogEntity;

            Year = futureLogEntity.Year;
            Months = new ObservableCollection<FutureLogMonthEntity>(futureLogEntity.Months.Select(x => AbstractTypeFactory<FutureLogMonthEntity>.TryCreateInstance().FromModel(x, primaryKeyResolvingMap)));

            return this;
        }
    }

    public class FutureLogMonthEntity : Entity
    {
        public Month Month { get; set; }


        #region Navigation Properties
        public CollectionEntity Collection { get; set; }

        public string FutureLogId { get; set; }

        public virtual FutureLog FutureLog { get; set; }

        #endregion


        public virtual FutureLogMonth ToModel(FutureLogMonth futureLogMonth)
        {
            if (futureLogMonth == null)
                throw new ArgumentNullException(nameof(futureLogMonth));

            futureLogMonth.Id = Id;
            futureLogMonth.Month = Month;

            return futureLogMonth;
        }

        public virtual FutureLogMonthEntity FromModel(FutureLogMonthEntity futureLogMonthEntity, PrimaryKeyResolvingMap primaryKeyResolvingMap)
        {
            if (futureLogMonthEntity == null)
                throw new ArgumentNullException(nameof(futureLogMonthEntity));

            primaryKeyResolvingMap.AddPair(futureLogMonthEntity, this);

            Id = futureLogMonthEntity.Id;
            Month = futureLogMonthEntity.Month;

            return this;
        }
    }
}
