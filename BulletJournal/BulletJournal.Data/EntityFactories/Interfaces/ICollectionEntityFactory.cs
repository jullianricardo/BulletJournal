using BulletJournal.Data.Model.Collection;
using BulletJournal.Models.Collection;

namespace BulletJournal.Data.EntityFactories.Interfaces
{
    public interface ICollectionEntityFactory
    {
        CollectionEntity CreateCollectionEntity(CollectionType collectionType);
    }
}
