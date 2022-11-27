using BulletJournal.Core.Common;
using BulletJournal.Core.Domain;
using BulletJournal.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Data.Model
{
    public class JournalEntity : Entity
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime DateCreated { get; set; }


        //public Index Index { get; set; }

        public virtual ObservableCollection<PageEntity> Pages { get; set; } = new ObservableCollection<PageEntity>();


        public virtual Journal ToModel(Journal journal)
        {
            if (journal == null) { throw new ArgumentNullException(nameof(journal)); }

            journal.Id = Id;
            journal.Name = Name;
            journal.Description = Description;
            journal.DateCreated = DateCreated;
            //journal.Pages = Pages.Select(x => x.)

            return journal;
        }

        public virtual JournalEntity FromModel(Journal journal, PrimaryKeyResolvingMap primaryKeyResolvingMap)
        {
            if (journal == null) { throw new ArgumentNullException(nameof(journal)); }

            primaryKeyResolvingMap.AddPair(journal, this);

            Id = journal.Id;
            Name = journal.Name;
            Description = journal.Description;
            DateCreated = journal.DateCreated;

            if (journal.Pages != null)
            {
                //Pages = new ObservableCollection<PageEntity>(journal.Pages.Select(x => new PageEntity { Id = x.Id, Number = x.Number }));
            }

            return this;
        }
    }
}
