using BulletJournal.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Data.Model.Collection
{
    public class CollectionEntity : Entity
    {
        public string? Name { get; set; }

        public string? Description { get; set; }
    }
}
