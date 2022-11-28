using BulletJournal.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulletJournal.Models
{
    public class Index : Entity
    {
        public Dictionary<Collection.Collection, List<Page>> Topics { get; set; }
    }
}
