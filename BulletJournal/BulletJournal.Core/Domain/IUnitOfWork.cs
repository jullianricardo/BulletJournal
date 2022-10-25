using System.Threading.Tasks;

namespace BulletJournal.Core.Domain
{
    public interface IUnitOfWork
    {
        int Commit();

        Task<int> CommitAsync();
    }
}
