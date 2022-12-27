using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Models.Settings.Interfaces
{
    public interface IUserSettings
    {
        public bool SplitCollectionsBetweenMultiplePages { get; set; }

        public bool AllowMultipleCollectionsPerPage { get; set; }

        int DefaultPageSize { get; set; }
    }
}
