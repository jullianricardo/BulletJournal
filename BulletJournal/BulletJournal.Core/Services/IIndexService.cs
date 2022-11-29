using System.Threading.Tasks;

namespace BulletJournal.Core.Services
{
    public interface IIndexService
    {
        Task<Models.Index> GetIndexById(string id);
        Task<Models.Index> GetIndexByJournalId(string journalId);
        public Task CreateIndex(Models.Index index);
        Task UpdateIndex(Models.Index index);
        Task DeleteIndex(string indexId);
    }
}
