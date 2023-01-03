using BulletJournal.Data.Model.Collection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulletJournal.Data.ModelConfigurations
{
    public class CollectionPageModelConfiguration : IEntityTypeConfiguration<CollectionPageEntity>
    {
        public void Configure(EntityTypeBuilder<CollectionPageEntity> builder)
        {
            builder.ToTable("CollectionPage").HasKey(x => x.Id);

            builder.Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Page).WithMany(x => x.CollectionPages).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Collection).WithMany(x => x.CollectionPages).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
