using BulletJournal.Models.Settings;
using BulletJournal.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Web.Services
{
    public class SettingsService : ISettingsService
    {
        public UserSettings GetDefaultUserSettings() { return new UserSettings().GetDefaultSettings() as UserSettings; }
        public UserSettings GetUserSettings() { return GetDefaultUserSettings(); }
    }
}
