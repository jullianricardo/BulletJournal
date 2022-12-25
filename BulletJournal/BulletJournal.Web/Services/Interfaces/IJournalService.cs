using BulletJournal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Web.Services.Interfaces
{
    public interface IJournalService
    {
        Task<IList<Journal>> GetJournalsByOwner(string ownerId);

        Task<Journal> GetOwnerDefaultJournal(string ownerId);

        Task<Journal> GetJournalById(string id);

        Task CreateJournal(Journal journal);
    }
}
