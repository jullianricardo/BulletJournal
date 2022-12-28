using BulletJournal.Models.Domain;

namespace BulletJournal.Data.EntityConverters.Interfaces
{
    public interface IEntityConverter<TModelEntity, TDatabaseEntity>
        where TModelEntity : Entity
        where TDatabaseEntity : Entity
    {
        TModelEntity ConvertFromDatabaseEntity(TDatabaseEntity databaseEntity, bool deepConversion = true);

        TDatabaseEntity ConvertFromModelEntity(TModelEntity modelEntity, bool deepConversion = true);
    }
}
