using BulletJournal.Core.Common;
using BulletJournal.Models.Calendar;
using BulletJournal.Models.Collection;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Security.Cryptography.X509Certificates;
using BulletJournal.Core.Domain;

namespace BulletJournal.Data.Model.Collection
{
    public class FutureLogEntity : CollectionEntity
    {
        public IDictionary<Month, CollectionEntity> Months { get; set; } = new Dictionary<Month, CollectionEntity>();

        public int Year { get; set; }


        public override FutureLog ToModel(Models.Collection.Collection collection)
        {
            var futureLog = base.ToModel(collection) as FutureLog;

            futureLog.Year = Year;

            var months = new Dictionary<Month, Models.Collection.Collection>();

            foreach (var month in Months)
                months[month.Key] = month.Value.ToModel(AbstractTypeFactory<Models.Collection.Collection>.TryCreateInstance());

            futureLog.Months = months;

            return futureLog;
        }

        public override FutureLogEntity FromModel(Models.Collection.Collection collection, PrimaryKeyResolvingMap primaryKeyResolvingMap)
        {
            var futureLogEntity = base.FromModel(collection, primaryKeyResolvingMap) as FutureLogEntity;

            Year = futureLogEntity.Year;

            var months = new Dictionary<Month, CollectionEntity>();

            foreach (var month in futureLogEntity.Months)
                months[month.Key] = month.Value;

            Months = months;

            return this;
        }
    }
}
