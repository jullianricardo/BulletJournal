using BulletJournal.Data.Model.Calendar;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulletJournal.Data.ModelConfigurations
{
    public class DayModelConfiguration : IEntityTypeConfiguration<DayEntity>
    {
        public void Configure(EntityTypeBuilder<DayEntity> builder)
        {
            builder.ToTable("Day").Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();
        }
    }
}
