using System;
using System.Collections.Generic;
using System.Text;

namespace BulletJournal.Core.Models.Calendar
{
    public class Holiday
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
