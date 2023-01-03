using BulletJournal.Data.Model.Collection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulletJournal.Data.ModelConfigurations
{
    public class LogModelConfiguration : IEntityTypeConfiguration<LogEntity>
    {
        public void Configure(EntityTypeBuilder<LogEntity> builder)
        {
            builder.ToTable("Log").HasKey(x => x.Id);

            builder.Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();
            builder.Property(x => x.Order).IsRequired().HasDefaultValue(1);

            builder.HasIndex(x => new { x.CollectionId, x.Order }).IsUnique();

            builder.HasOne(x => x.Collection).WithMany(x => x.Logs).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
