using BulletJournal.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Models
{
    public class Journal : Entity
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime DateCreated { get; set; }


        public Index? Index { get; set; }

        public List<Page>? Pages { get; set; }

    }
}
