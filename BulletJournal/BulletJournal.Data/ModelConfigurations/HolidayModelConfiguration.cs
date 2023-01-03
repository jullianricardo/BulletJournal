using BulletJournal.Data.Model.Calendar;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulletJournal.Data.ModelConfigurations
{
    public class HolidayModelConfiguration : IEntityTypeConfiguration<HolidayEntity>
    {
        public void Configure(EntityTypeBuilder<HolidayEntity> builder)
        {
            builder.ToTable("Holiday").Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();
        }
    }
}
