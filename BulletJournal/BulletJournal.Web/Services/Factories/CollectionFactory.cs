using BulletJournal.Models.Collection;
using BulletJournal.Web.Services.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Web.Services.Factories
{
    public class CollectionFactory : ICollectionFactory
    {
        public Collection CreateCollection(CollectionType collectionType)
        {
            return collectionType switch
            {
                CollectionType.DailyLog => new DailyLog(),
                CollectionType.FutureLog => new FutureLog(),
                CollectionType.MonthlyLog => new MonthlyLog(),
                CollectionType.List => new ListCollection(),
                CollectionType.UserDefined => new UserDefinedLog(),
                _ => null,
            };
        }
    }
}
