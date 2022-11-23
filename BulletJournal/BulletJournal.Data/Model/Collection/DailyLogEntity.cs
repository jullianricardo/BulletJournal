using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Data.Model.Collection
{
    public class DailyLogEntity : CollectionEntity
    {
        public DateTime CurrentDay { get; set; }
    }
}
