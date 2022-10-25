using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Core.Domain
{
    public interface IRepository : IDisposable
    {
        IUnitOfWork UnitOfWork { get; }

        void Attach<T>(T item) where T : class;

        void Add<T>(T item) where T : class;

        void Update<T>(T item) where T : class;

        void Remove<T>(T item) where T : class;
    }
}
