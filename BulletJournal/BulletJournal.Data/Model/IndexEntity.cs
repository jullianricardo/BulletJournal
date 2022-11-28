using BulletJournal.Core.Domain;
using BulletJournal.Data.Model.Collection;
using BulletJournal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Data.Model
{
    public class IndexEntity : Entity
    {
        public Dictionary<CollectionEntity, List<PageEntity>> Topics { get; set; } = new Dictionary<CollectionEntity, List<PageEntity>>();
    }
}
