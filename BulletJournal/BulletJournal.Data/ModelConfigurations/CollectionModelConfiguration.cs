using BulletJournal.Data.Model.Collection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulletJournal.Data.ModelConfigurations
{
    public class CollectionModelConfiguration : IEntityTypeConfiguration<CollectionEntity>
    {
        public void Configure(EntityTypeBuilder<CollectionEntity> builder)
        {
            builder.ToTable("Collection").HasKey(x => x.Id);

            builder.Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();
            builder.Property(x => x.Order).IsRequired().HasDefaultValue(1);

            builder.HasIndex(x => new { x.JournalId, x.Order }).IsUnique();

            builder.HasDiscriminator(x => x.Type)
                   .HasValue<DailyLogEntity>(Models.Collection.CollectionType.DailyLog)
                   .HasValue<MonthlyLogEntity>(Models.Collection.CollectionType.MonthlyLog)
                   .HasValue<FutureLogEntity>(Models.Collection.CollectionType.FutureLog)
                   .IsComplete(false);

            builder.HasOne(x => x.Journal).WithMany().OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
