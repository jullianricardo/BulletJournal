using BulletJournal.Data.Model.Collection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulletJournal.Data.ModelConfigurations
{
    public class FutureLogMonthModelConfiguration : IEntityTypeConfiguration<FutureLogMonthEntity>
    {
        public void Configure(EntityTypeBuilder<FutureLogMonthEntity> builder)
        {
            builder.ToTable("FutureLogMonth").Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();
        }
    }
}
