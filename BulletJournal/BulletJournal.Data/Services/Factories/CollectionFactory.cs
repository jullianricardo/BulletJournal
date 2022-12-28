using BulletJournal.Models.Collection;
using BulletJournal.Core.Services.Factories;

namespace BulletJournal.Data.Services.Factories
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
