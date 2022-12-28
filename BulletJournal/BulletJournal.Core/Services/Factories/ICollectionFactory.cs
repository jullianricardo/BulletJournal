using BulletJournal.Models.Collection;

namespace BulletJournal.Core.Services.Factories
{
    public interface ICollectionFactory
    {
        Collection CreateCollection(CollectionType collectionType);
    }
}
