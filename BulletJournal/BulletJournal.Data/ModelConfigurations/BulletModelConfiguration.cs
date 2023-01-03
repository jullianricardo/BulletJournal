using BulletJournal.Data.Model.Bullet;
using BulletJournal.Models.Bullet;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulletJournal.Data.ModelConfigurations
{
    public class BulletModelConfiguration : IEntityTypeConfiguration<BulletEntity>
    {
        public void Configure(EntityTypeBuilder<BulletEntity> builder)
        {
            builder.ToTable("Bullet").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();
            builder.Property(x => x.Order).IsRequired().HasDefaultValue(1);

            builder.HasIndex(x => new { x.LogId, x.Order }).IsUnique();

            builder.HasDiscriminator(x => x.Type)
                .HasValue<TaskEntity>(BulletType.Task)
                .HasValue<NoteEntity>(BulletType.Note)
            .HasValue<EventEntity>(BulletType.Event);

            builder.HasOne(m => m.Log).WithMany(x => x.Bullets).HasForeignKey(x => x.LogId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(m => m.Parent).WithMany().HasForeignKey(m => m.ParentId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
