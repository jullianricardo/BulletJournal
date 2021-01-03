using System;
using System.Collections.Generic;
using System.Text;

namespace BulletJournal.Models
{
    public class Page
    {
        public long Id { get; set; }

        public int Number { get; set; }

        public List<Collection.Collection> Collections { get; set; }
    }
}
