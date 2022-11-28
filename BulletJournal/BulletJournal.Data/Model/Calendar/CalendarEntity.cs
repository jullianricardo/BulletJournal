using BulletJournal.Core.Common;
using BulletJournal.Core.Domain;
using BulletJournal.Models.Calendar;
using System.Collections.ObjectModel;

namespace BulletJournal.Data.Model.Calendar
{
    public class CalendarEntity : Entity
    {
        public ObservableCollection<DayEntity> Days { get; set; } = new NullCollection<DayEntity>();


        public virtual Models.Calendar.Calendar ToModel(Models.Calendar.Calendar calendar)
        {
            calendar.Id = Id;
            calendar.Days = Days.Select(x => x.ToModel(AbstractTypeFactory<Day>.TryCreateInstance())).ToList();

            return calendar;
        }

        public virtual CalendarEntity FromModel(Models.Calendar.Calendar calendar, PrimaryKeyResolvingMap primaryKeyResolvingMap)
        {
            primaryKeyResolvingMap.AddPair(calendar, this);

            Id = calendar.Id;
            Days = new ObservableCollection<DayEntity>(calendar.Days.Select(x => AbstractTypeFactory<DayEntity>.TryCreateInstance().FromModel(x, primaryKeyResolvingMap)));

            return this;
        }
    }
}
