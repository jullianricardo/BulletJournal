using BulletJournal.Core.Common;
using BulletJournal.Core.Domain;
using BulletJournal.Core.Extensions;
using BulletJournal.Data.Model.Identity;
using BulletJournal.Models;
using BulletJournal.Models.Domain;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

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

        public string OwnerId { get; set; }

        public virtual IndexEntity Index { get; set; }

        public virtual ObservableCollection<PageEntity> Pages { get; set; } = new ObservableCollection<PageEntity>();

        #endregion

        public virtual Journal ToModel(Journal journal)
        {
            journal.Id = Id;
            journal.OwnerId = OwnerId;
            journal.CreatedAt = CreatedAt;
            journal.UpdatedAt = UpdatedAt;

            journal.Name = Name;
            journal.Description = Description;
            journal.Year = Year;
            journal.IsDefault = IsDefault;

            journal.Index = Index?.ToModel(AbstractTypeFactory<Models.Index>.TryCreateInstance());
            //journal.Spreads = Pages.Select(x => x.ToModel(AbstractTypeFactory<Spread>.TryCreateInstance())).ToList();

            return journal;
        }

        public virtual JournalEntity FromModel(Journal journal, PrimaryKeyResolvingMap primaryKeyResolvingMap)
        {
            primaryKeyResolvingMap.AddPair(journal, this);

            Id = journal.Id;
            OwnerId = journal.OwnerId;
            CreatedAt = journal.CreatedAt;
            UpdatedAt = journal.UpdatedAt;

            Name = journal.Name;
            Description = journal.Description;
            Year = journal.Year;
            IsDefault = journal.IsDefault;

            if (journal.Index != null)
                Index = AbstractTypeFactory<IndexEntity>.TryCreateInstance().FromModel(journal.Index, primaryKeyResolvingMap);

            //if (journal.Pages != null)
            //{
            //    var pages = journal.Pages.Select(x => AbstractTypeFactory<PageEntity>.TryCreateInstance().FromModel(x, primaryKeyResolvingMap));
            //    Pages = new ObservableCollection<PageEntity>(pages);
            //}

            return this;
        }

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
