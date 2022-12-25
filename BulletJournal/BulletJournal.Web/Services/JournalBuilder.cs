using BulletJournal.Models;
using BulletJournal.Web.Models.Options;
using BulletJournal.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Web.Services
{
    public class JournalBuilder : IJournalBuilder
    {
        public Journal BuildJournal(Journal journal, JournalBuilderOptions builderOptions)
        {
            if (journal == null)
                throw new ArgumentNullException("No journal to build");

            if (builderOptions.BuildIndex)
            {
                var index = new BulletJournal.Models.Index
                {
                    Topics = new List<Topic>()
                };

                journal.Index = index;
            }

            return journal;
        }
    }
}
