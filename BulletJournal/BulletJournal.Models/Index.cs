using BulletJournal.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulletJournal.Models
{
    public class Index : Entity
    {
        public List<Topic> Topics { get; set; } = new List<Topic>();
    }
}
