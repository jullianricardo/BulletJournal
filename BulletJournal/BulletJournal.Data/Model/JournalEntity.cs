using BulletJournal.Core.Common;
using BulletJournal.Core.Extensions;
using BulletJournal.Models.Domain;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulletJournal.Data.Model
{
    public class JournalEntity : Entity
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        [StringLength(128)]
        public string Description { get; set; }

        [Required]
        [Range(1900, 2100)]
        public int Year { get; set; }

        public bool IsDefault { get; set; }



        #region Navigation Properties

        [ForeignKey("Page")]
        public string CurrentPage { get; set; }

        public string OwnerId { get; set; }

        public virtual IndexEntity Index { get; set; }

        public virtual ObservableCollection<PageEntity> Pages { get; set; } = new ObservableCollection<PageEntity>();

        #endregion      

        public virtual void Patch(JournalEntity target)
        {
            target.Name = Name;
            target.Description = Description;
            target.Year = Year;
            target.IsDefault = IsDefault;

            if (Index != null)
                Index.Patch(target.Index);

            if (!Pages.IsNullCollection())
            {
                var comparer = AnonymousComparer.Create((PageEntity entity) => entity.Id);
                Pages.Patch(target.Pages, comparer, (sourceEntity, targetEntity) => targetEntity.Id = sourceEntity.Id);
            }
        }
    }
}
