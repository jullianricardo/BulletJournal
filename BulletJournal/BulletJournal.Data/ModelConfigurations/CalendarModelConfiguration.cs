using BulletJournal.Data.Model.Calendar;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulletJournal.Data.ModelConfigurations
{
    public class CalendarModelConfiguration : IEntityTypeConfiguration<CalendarEntity>
    {
        public void Configure(EntityTypeBuilder<CalendarEntity> builder)
        {
            builder.ToTable("Calendar").Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();
        }
    }
}
