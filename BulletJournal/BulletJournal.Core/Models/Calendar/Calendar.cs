using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Core.Models.Calendar
{
    public class Calendar
    {
        public long Id { get; set; }

        public List<Day> Days{ get; set; }
    }
}
