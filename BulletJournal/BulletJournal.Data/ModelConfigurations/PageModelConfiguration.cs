using BulletJournal.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulletJournal.Data.ModelConfigurations
{
	public class PageModelConfiguration : IEntityTypeConfiguration<PageEntity>
	{
		public void Configure(EntityTypeBuilder<PageEntity> builder)
		{
			builder.ToTable("Page").HasKey(x => x.Id);

			builder.Property(x => x.Id).HasMaxLength(128).ValueGeneratedOnAdd();
			builder.Property(x => x.Number).IsRequired().HasDefaultValue(1);

			builder.HasIndex(x => new { x.JournalId, x.Number }).IsUnique();

			builder.HasOne(x => x.Journal).WithMany(x => x.Pages).OnDelete(DeleteBehavior.Cascade);
		}
	}
}
