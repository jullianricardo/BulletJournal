using BulletJournal.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulletJournal.Data.ModelConfigurations
{
    public class TopicModelConfiguration : IEntityTypeConfiguration<TopicEntity>
    {
        public void Configure(EntityTypeBuilder<TopicEntity> builder)
        {
            builder.ToTable("Topic").HasKey(x => x.Id);

            builder.Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Index).WithMany(x => x.Topics).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
