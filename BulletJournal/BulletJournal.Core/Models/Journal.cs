﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Core.Models
{
    public class Journal
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DateCreated { get; set; }


        public Index Index { get; set; }

        public List<Page> Pages{ get; set; }

    }
}
