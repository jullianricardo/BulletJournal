using BulletJournal.Core.Common;
using BulletJournal.Models.Domain;
using BulletJournal.Models.Calendar;

namespace BulletJournal.Data.Model.Calendar
{
    public class HolidayEntity : Entity
    {
        public DateTime Date { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }


        public virtual Holiday ToModel(Holiday holiday)
        {
            if (holiday == null)
            { throw new ArgumentNullException(nameof(holiday)); }

            holiday.Id = Id;
            holiday.Name = Name;
            holiday.Description = Description;

            return holiday;
        }

        public virtual HolidayEntity FromModel(Holiday holiday, PrimaryKeyResolvingMap primaryKeyResolvingMap)
        {
            if (holiday == null)
            { throw new ArgumentNullException(nameof(holiday)); }

            primaryKeyResolvingMap.AddPair(holiday, this);

            Id = holiday.Id;
            Name = holiday.Name;
            Description = holiday.Description;

            return this;
        }
    }
}
