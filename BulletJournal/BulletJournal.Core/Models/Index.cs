using System;
using System.Collections.Generic;
using System.Text;

namespace BulletJournal.Core.Models
{
    public class Index
    {
        public Dictionary<Collection.Collection, List<Page>> Topics { get; set; }
    }
}
