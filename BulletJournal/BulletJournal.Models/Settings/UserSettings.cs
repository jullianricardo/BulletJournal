using BulletJournal.Models.Settings.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Models.Settings
{
    public class UserSettings : Settings, IUserSettings
    {
        public bool SplitCollectionsBetweenMultiplePages { get; set; }

        public bool AllowMultipleCollectionsPerPage { get; set; }

        public int DefaultPageSize { get; set; }

        public override Settings GetDefaultSettings()
        {
            return new UserSettings()
            {
                DefaultPageSize = 100,
                SplitCollectionsBetweenMultiplePages = true,
                AllowMultipleCollectionsPerPage = true
            };
        }
    }
}
