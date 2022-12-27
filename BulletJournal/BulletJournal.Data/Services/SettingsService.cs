using BulletJournal.Core.Services;
using BulletJournal.Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Data.Services
{
    public class SettingsService : ISettingsService
    {
        public UserSettings GetDefaultUserSettings() { return new UserSettings().GetDefaultSettings() as UserSettings; }
        public UserSettings GetUserSettings() { return GetDefaultUserSettings(); }
    }
}
