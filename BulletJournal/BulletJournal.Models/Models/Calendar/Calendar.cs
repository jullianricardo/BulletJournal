using BulletJournal.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Models.Calendar
{
    public class Calendar : Entity
    {
        public List<Day> Days { get; set; } = new List<Day>();
    }
}
