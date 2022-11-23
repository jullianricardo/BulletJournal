using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Core.Domain
{
    public interface IEntity
    {
        public string Id { get; set; }
    }
}
