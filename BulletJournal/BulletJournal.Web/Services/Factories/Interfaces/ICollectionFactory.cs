using BulletJournal.Models.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Web.Services.Factories.Interfaces
{
    public interface ICollectionFactory
    {
        Collection CreateCollection(CollectionType collectionType);
    }
}
