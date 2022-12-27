using BulletJournal.Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Core.Services
{
    public interface ISettingsService
    {
        UserSettings GetDefaultUserSettings();

        UserSettings GetUserSettings();
    }
}
