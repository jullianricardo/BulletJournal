using BulletJournal.Data.EntityFactories.Interfaces;
using BulletJournal.Data.Model.Collection;
using BulletJournal.Models.Collection;

namespace BulletJournal.Data.EntityFactories
{
    public class CollectionEntityFactory : ICollectionEntityFactory
    {
        public CollectionEntity CreateCollectionEntity(CollectionType collectionType)
        {
            return collectionType switch
            {
                CollectionType.DailyLog => new DailyLogEntity(),
                CollectionType.FutureLog => new FutureLogEntity(),
                CollectionType.MonthlyLog => new MonthlyLogEntity(),
                //CollectionType.List => new ListCollectionEntity(),
                //CollectionType.UserDefined => new UserDefinedLogEntity(),
                _ => null,
            };
        }
    }
}
