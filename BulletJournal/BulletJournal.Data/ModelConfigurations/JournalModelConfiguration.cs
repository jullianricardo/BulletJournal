using BulletJournal.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulletJournal.Data.ModelConfigurations
{
    public class JournalModelConfiguration : IEntityTypeConfiguration<JournalEntity>
    {
        public void Configure(EntityTypeBuilder<JournalEntity> builder)
        {
            builder.ToTable("Journal").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();
        }
    }
}
