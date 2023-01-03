using BulletJournal.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulletJournal.Data.ModelConfigurations
{
    public class IndexModelConfiguration : IEntityTypeConfiguration<IndexEntity>
    {
        public void Configure(EntityTypeBuilder<IndexEntity> builder)
        {
            builder.ToTable("Index").HasKey(x => x.Id);

            builder.Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Journal).WithOne(x => x.Index).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
