using BulletJournal.Models.Settings.Interfaces;

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
                DefaultPageSize = 20,
                SplitCollectionsBetweenMultiplePages = true,
                AllowMultipleCollectionsPerPage = true
            };
        }
    }
}
