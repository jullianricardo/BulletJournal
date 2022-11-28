using BulletJournal.Core.Common;
using BulletJournal.Core.Domain;
using BulletJournal.Data.Model.Collection;
using BulletJournal.Models.Calendar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Data.Model.Calendar
{
    public class DayEntity : Entity
    {
        public int Number { get; set; }

        public WeekDay WeekDay { get; set; }

        public bool IsHoliday { get; set; }

        #region Navigation Properties

        public virtual HolidayEntity? Holiday { get; set; }

        public virtual CollectionEntity? Entries { get; set; }

        #endregion

        public virtual Day ToModel(Day day)
        {
            if (day == null)
                throw new ArgumentNullException(nameof(day));

            day.Id = Id;
            day.Number = Number;
            day.WeekDay = WeekDay;
            day.IsHoliday = IsHoliday;

            return day;
        }

        public virtual DayEntity FromModel(Day day, PrimaryKeyResolvingMap primaryKeyResolvingMap)
        {
            if (day == null)
                throw new ArgumentNullException(nameof(day));

            Id = day.Id;
            Number = day.Number;
            WeekDay = day.WeekDay;
            IsHoliday = day.IsHoliday;

            return this;
        }
    }
}
