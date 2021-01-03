using System;
using System.Collections.Generic;
using System.Text;

namespace BulletJournal.Models
{
    public class Index
    {
        public long Id { get; set; }

        public Dictionary<Collection.Collection, List<Page>> Topics { get; set; }
    }
}
