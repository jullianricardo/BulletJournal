using BulletJournal.Models;
using BulletJournal.Web.Models.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Web.Services.Builders.Interfaces
{
    public interface IJournalBuilder
    {
        Journal BuildJournal(Journal journal, JournalBuilderOptions builderOptions);
    }
}
