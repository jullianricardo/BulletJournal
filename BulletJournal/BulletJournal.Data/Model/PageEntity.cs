using BulletJournal.Core.Domain;
using BulletJournal.Data.Model.Collection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Data.Model
{
    public class PageEntity : Entity
    {
        public int Number { get; set; }

        public virtual ObservableCollection<CollectionEntity> Collections { get; set; } = new NullCollection<CollectionEntity>();
    }
}
