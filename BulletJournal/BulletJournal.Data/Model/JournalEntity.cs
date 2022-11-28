using BulletJournal.Core.Common;
using BulletJournal.Core.Domain;
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
        public string? Name { get; set; }

        [Required]
        [StringLength(128)]
        public string? Description { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }


        #region Navigation Properties

        public virtual IndexEntity? Index { get; set; }

        public virtual ObservableCollection<PageEntity> Pages { get; set; } = new ObservableCollection<PageEntity>();

        #endregion

        public virtual Journal ToModel(Journal journal)
        {
            if (journal == null)
            { throw new ArgumentNullException(nameof(journal)); }

            journal.Id = Id;
            journal.Name = Name;
            journal.Description = Description;
            journal.DateCreated = DateCreated;
            journal.Pages = Pages.Select(x => x.ToModel(AbstractTypeFactory<Page>.TryCreateInstance())).ToList();

            return journal;
        }

        public virtual JournalEntity FromModel(Journal journal, PrimaryKeyResolvingMap primaryKeyResolvingMap)
        {
            if (journal == null)
            { throw new ArgumentNullException(nameof(journal)); }

            primaryKeyResolvingMap.AddPair(journal, this);

            Id = journal.Id;
            Name = journal.Name;
            Description = journal.Description;
            DateCreated = journal.DateCreated;

            if (journal.Pages != null)
            {
                var pages = journal.Pages.Select(x => AbstractTypeFactory<PageEntity>.TryCreateInstance().FromModel(x, primaryKeyResolvingMap));
                Pages = new ObservableCollection<PageEntity>(pages);
            }

            return this;
        }
    }
}
