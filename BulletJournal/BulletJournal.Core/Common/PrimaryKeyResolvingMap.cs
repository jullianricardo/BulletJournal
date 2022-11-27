using BulletJournal.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulletJournal.Core.Common
{
    /// <summary>
    /// Helper class used for resolving model object primary keys when persisted in persistent infrastructure
    /// Used in model to db model converters
    /// </summary>
    public class PrimaryKeyResolvingMap
    {
        private readonly Dictionary<IEntity, IEntity> _resolvingMap = new Dictionary<IEntity, IEntity>();

        public void AddPair(IEntity transientEntity, IEntity persistentEntity)
        {
            _resolvingMap[transientEntity] = persistentEntity;
        }

        public void ResolvePrimaryKeys()
        {
            foreach (var pair in _resolvingMap)
            {
                if (string.IsNullOrEmpty(pair.Key.Id) && !string.IsNullOrEmpty(pair.Value.Id))
                {
                    pair.Key.Id = pair.Value.Id;
                }
            }
        }
    }
}
