using BulletJournal.Models;
using BulletJournal.Web.Models.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Web.Services.Builders.Interfaces
{
    public interface IFutureLogBuilder
    {
        BulletJournal.Models.Collection.FutureLog BuildDefaultFutureLog();
    }
}
