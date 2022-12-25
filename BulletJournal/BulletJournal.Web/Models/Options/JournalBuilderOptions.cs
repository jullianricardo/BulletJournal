using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Web.Models.Options
{
    public class JournalBuilderOptions
    {
        public bool BuildIndex { get; set; } = true;

        public bool BuildFutureLog { get; set; } = true;

        public bool BuildMonthlyLog { get; set; } = true;

        public bool BuildDailyLog { get; set; } = true;
    }
}
