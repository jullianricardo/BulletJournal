using BulletJournal.Data.EntityConverters.Interfaces;
using BulletJournal.Data.Model.Collection;
using BulletJournal.Models.Collection;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace BulletJournal.Data.EntityConverters
{
    public class CollectionEntityConverter : ICollectionEntityConverter
    {
        private readonly IServiceProvider _serviceProvider;

        public CollectionEntityConverter(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Collection ConvertFromDatabaseEntity(CollectionEntity databaseEntity, bool deepConversion = true)
        {
            Collection collection;

            switch (databaseEntity)
            {
                case FutureLogEntity futureLogEntity:
                    var futureLogEntityConverter = _serviceProvider.GetService<IFutureLogEntityConverter>();
                    var futureLog = futureLogEntityConverter.ConvertFromDatabaseEntity(futureLogEntity);
                    collection = futureLog;

                    break;

                case DailyLogEntity dailyLogEntity:
                    var dailyLogEntityConverter = _serviceProvider.GetService<IDailyLogEntityConverter>();
                    var dailyLog = dailyLogEntityConverter.ConvertFromDatabaseEntity(dailyLogEntity);
                    collection = dailyLog;

                    break;

                case MonthlyLogEntity MonthlyLogEntity:
                    var MonthlyLogEntityConverter = _serviceProvider.GetService<IMonthlyLogEntityConverter>();
                    var MonthlyLog = MonthlyLogEntityConverter.ConvertFromDatabaseEntity(MonthlyLogEntity);
                    collection = MonthlyLog;

                    break;

                case null:
                default:
                    collection = null;
                    break;

            }

            return collection;
        }


        public CollectionEntity ConvertFromModelEntity(Collection modelEntity, bool deepConversion = true)
        {
            CollectionEntity collectionEntity;

            switch (modelEntity)
            {
                case FutureLog futureLog:
                    var futureLogConverter = _serviceProvider.GetService<IFutureLogEntityConverter>();
                    var futureLogEntity = futureLogConverter.ConvertFromModelEntity(futureLog);
                    collectionEntity = futureLogEntity;

                    break;

                case DailyLog dailyLog:
                    var dailyLogConverter = _serviceProvider.GetService<IDailyLogEntityConverter>();
                    var dailyLogEntity = dailyLogConverter.ConvertFromModelEntity(dailyLog);
                    collectionEntity = dailyLogEntity;

                    break;

                case MonthlyLog monthlyLog:
                    var monthlyLogConverter = _serviceProvider.GetService<IMonthlyLogEntityConverter>();
                    var monthlyLogEntity = monthlyLogConverter.ConvertFromModelEntity(monthlyLog);
                    collectionEntity = monthlyLogEntity;

                    break;

                case null:
                default:
                    collectionEntity = null;
                    break;

            }

            return collectionEntity;
        }
    }

    #region Collections Converters

    public interface IFutureLogEntityConverter : IEntityConverter<FutureLog, FutureLogEntity> { }

    public class FutureLogEntityConverter : IFutureLogEntityConverter
    {
        private readonly ILogEntityConverter _logEntityConverter;

        public FutureLogEntityConverter(ILogEntityConverter logEntityConverter)
        {
            _logEntityConverter = logEntityConverter;
        }

        public FutureLog ConvertFromDatabaseEntity(FutureLogEntity databaseEntity, bool deepConversion = true)
        {
            var modelEntity = new FutureLog
            {
                Id = databaseEntity.Id,
                Description = databaseEntity.Description,
                Name = databaseEntity.Name,
                Year = databaseEntity.Year,
                Order = databaseEntity.Order,
                CreatedAt = databaseEntity.CreatedAt,
                UpdatedAt = databaseEntity.UpdatedAt,
            };

            if (deepConversion)
            {
                if (databaseEntity.Logs != null)
                {
                    var logs = databaseEntity.Logs.Select(x => _logEntityConverter.ConvertFromDatabaseEntity(x));
                    modelEntity.Logs = new SortedList<int, Models.Log>(logs.ToDictionary(x => x.Order));
                }
            }

            return modelEntity;
        }

        public FutureLogEntity ConvertFromModelEntity(FutureLog modelEntity, bool deepConversion = true)
        {
            var databaseEntity = new FutureLogEntity
            {
                Id = modelEntity.Id,
                Description = modelEntity.Description,
                Name = modelEntity.Name,
                Year = modelEntity.Year,
                Order = modelEntity.Order,
                CreatedAt = modelEntity.CreatedAt,
                UpdatedAt = modelEntity.UpdatedAt,
            };

            if (deepConversion)
            {
                if (modelEntity.Logs != null)
                {
                    var logs = modelEntity.Logs.Select(x => _logEntityConverter.ConvertFromModelEntity(x.Value));
                    databaseEntity.Logs = new ObservableCollection<LogEntity>(logs);
                }
            }

            return databaseEntity;
        }
    }


    public interface IDailyLogEntityConverter : IEntityConverter<DailyLog, DailyLogEntity> { }

    public class DailyLogEntityConverter : IDailyLogEntityConverter
    {
        private readonly ILogEntityConverter _logEntityConverter;

        public DailyLogEntityConverter(ILogEntityConverter logEntityConverter)
        {
            _logEntityConverter = logEntityConverter;
        }

        public DailyLog ConvertFromDatabaseEntity(DailyLogEntity databaseEntity, bool deepConversion = true)
        {
            var modelEntity = new DailyLog
            {
                Id = databaseEntity.Id,
                Description = databaseEntity.Description,
                Name = databaseEntity.Name,
                Order = databaseEntity.Order,
                CurrentDay = databaseEntity.CurrentDay,
                CreatedAt = databaseEntity.CreatedAt,
                UpdatedAt = databaseEntity.UpdatedAt,
            };

            if (deepConversion)
            {
                if (databaseEntity.Logs != null)
                {
                    var logs = databaseEntity.Logs.Select(x => _logEntityConverter.ConvertFromDatabaseEntity(x));
                    modelEntity.Logs = new SortedList<int, Models.Log>(logs.ToDictionary(x => x.Order));
                }
            }

            return modelEntity;
        }

        public DailyLogEntity ConvertFromModelEntity(DailyLog modelEntity, bool deepConversion = true)
        {
            var databaseEntity = new DailyLogEntity
            {
                Id = modelEntity.Id,
                Description = modelEntity.Description,
                Name = modelEntity.Name,
                Order = modelEntity.Order,
                CurrentDay = modelEntity.CurrentDay,
                CreatedAt = modelEntity.CreatedAt,
                UpdatedAt = modelEntity.UpdatedAt,
            };

            if (deepConversion)
            {
                if (modelEntity.Logs != null)
                {
                    var logs = modelEntity.Logs.Select(x => _logEntityConverter.ConvertFromModelEntity(x.Value));
                    databaseEntity.Logs = new ObservableCollection<LogEntity>(logs);
                }
            }

            return databaseEntity;
        }
    }


    public interface IMonthlyLogEntityConverter : IEntityConverter<MonthlyLog, MonthlyLogEntity> { }

    public class MonthlyLogEntityConverter : IMonthlyLogEntityConverter
    {
        private readonly ILogEntityConverter _logEntityConverter;

        public MonthlyLogEntityConverter(ILogEntityConverter logEntityConverter)
        {
            _logEntityConverter = logEntityConverter;
        }

        public MonthlyLog ConvertFromDatabaseEntity(MonthlyLogEntity databaseEntity, bool deepConversion = true)
        {
            var modelEntity = new MonthlyLog
            {
                Id = databaseEntity.Id,
                Description = databaseEntity.Description,
                Name = databaseEntity.Name,
                Order = databaseEntity.Order,
                Month = databaseEntity.Month,
                CreatedAt = databaseEntity.CreatedAt,
                UpdatedAt = databaseEntity.UpdatedAt,
            };

            if (deepConversion)
            {
                if (modelEntity.Logs != null)
                {
                    var logs = modelEntity.Logs.Select(x => _logEntityConverter.ConvertFromModelEntity(x.Value));
                    databaseEntity.Logs = new ObservableCollection<LogEntity>(logs);
                }
            }

            return modelEntity;
        }

        public MonthlyLogEntity ConvertFromModelEntity(MonthlyLog modelEntity, bool deepConversion = true)
        {
            var databaseEntity = new MonthlyLogEntity
            {
                Id = modelEntity.Id,
                Description = modelEntity.Description,
                Name = modelEntity.Name,
                Order = modelEntity.Order,
                Month = modelEntity.Month,
                CreatedAt = modelEntity.CreatedAt,
                UpdatedAt = modelEntity.UpdatedAt,
            };

            if (deepConversion)
            {
                if (modelEntity.Logs != null)
                {
                    var logs = modelEntity.Logs.Select(x => _logEntityConverter.ConvertFromModelEntity(x.Value));
                    databaseEntity.Logs = new ObservableCollection<LogEntity>(logs);
                }
            }

            return databaseEntity;
        }
    }

    #endregion
}
