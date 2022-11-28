using BulletJournal.Core.Domain;
using BulletJournal.Data.Model.Collection;
using BulletJournal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Data.Model
{
    public class IndexEntity : Entity
    {

        #region Navigation Properties

        public string? JournalId { get; set; }

        public JournalEntity? Journal { get; set; }

        #endregion

        [NotMapped]
        public Dictionary<CollectionEntity, List<PageEntity>> Topics { get; set; } = new Dictionary<CollectionEntity, List<PageEntity>>();
    }
}
