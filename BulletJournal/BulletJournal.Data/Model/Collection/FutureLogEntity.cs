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
        public override CollectionType Type
        {
            get { return CollectionType.FutureLog; }
            set { }
        }

        public int Year { get; set; }

        #region Navigation Properties

        public ObservableCollection<FutureLogMonthEntity> Months { get; set; } = new NullCollection<FutureLogMonthEntity>();

        #endregion
    }

    public class FutureLogMonthEntity : Entity
    {
        public Month Month { get; set; }


        #region Navigation Properties
        public LogEntity Log { get; set; }

        public string FutureLogId { get; set; }

        public virtual FutureLogEntity FutureLog { get; set; }

        #endregion
    }
}
