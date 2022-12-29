using BulletJournal.Data.EntityConverters.Interfaces;
using BulletJournal.Data.Model.Bullet;
using BulletJournal.Models.Bullet;
using Microsoft.Extensions.DependencyInjection;

namespace BulletJournal.Data.EntityConverters
{
    public class BulletEntityConverter : IBulletEntityConverter
    {
        private readonly IServiceProvider _serviceProvider;

        public BulletEntityConverter(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Bullet ConvertFromDatabaseEntity(BulletEntity databaseEntity, bool deepConversion = true)
        {
            Bullet bullet;

            switch (databaseEntity)
            {
                case TaskEntity taskEntity:
                    var taskEntityConverter = _serviceProvider.GetService<ITaskEntityConverter>();
                    var task = taskEntityConverter.ConvertFromDatabaseEntity(taskEntity);
                    bullet = task;

                    break;

                case NoteEntity noteEntity:
                    var noteEntityConverter = _serviceProvider.GetService<INoteEntityConverter>();
                    var note = noteEntityConverter.ConvertFromDatabaseEntity(noteEntity);
                    bullet = note;

                    break;

                case EventEntity eventEntity:
                    var eventEntityConverter = _serviceProvider.GetService<IEventEntityConverter>();
                    var modelEvent = eventEntityConverter.ConvertFromDatabaseEntity(eventEntity);
                    bullet = modelEvent;

                    break;

                case null:
                default:
                    bullet = null;
                    break;

            }

            return bullet;
        }


        public BulletEntity ConvertFromModelEntity(Bullet modelEntity, bool deepConversion = true)
        {
            BulletEntity bulletEntity;

            switch (modelEntity)
            {
                case Models.Bullet.Task task:
                    var taskConverter = _serviceProvider.GetService<ITaskEntityConverter>();
                    var taskEntity = taskConverter.ConvertFromModelEntity(task);
                    bulletEntity = taskEntity;

                    break;

                case Note note:
                    var noteConverter = _serviceProvider.GetService<INoteEntityConverter>();
                    var noteEntity = noteConverter.ConvertFromModelEntity(note);
                    bulletEntity = noteEntity;

                    break;

                case Event modelEvent:
                    var eventConverter = _serviceProvider.GetService<IEventEntityConverter>();
                    var eventEntity = eventConverter.ConvertFromModelEntity(modelEvent);
                    bulletEntity = eventEntity;

                    break;

                case null:
                default:
                    bulletEntity = null;
                    break;

            }

            return bulletEntity;
        }
    }

    #region Collections Converters

    public interface ITaskEntityConverter : IEntityConverter<Models.Bullet.Task, TaskEntity> { }

    public class TaskEntityConverter : ITaskEntityConverter
    {
        public Models.Bullet.Task ConvertFromDatabaseEntity(TaskEntity databaseEntity, bool deepConversion = true)
        {
            var modelEntity = new Models.Bullet.Task
            {
                Id = databaseEntity.Id,
                Description = databaseEntity.Description,
                Signifier = databaseEntity.Signifier,
                DateCreated = databaseEntity.DateCreated,
                IsActive = databaseEntity.IsActive,
                Status = databaseEntity.Status,
                CreatedAt = databaseEntity.CreatedAt,
                UpdatedAt = databaseEntity.UpdatedAt,
            };

            if (deepConversion)
            {
                //if (databaseEntity.Logs != null)
                //{
                //    var logs = databaseEntity.Logs.Select(x => _logEntityConverter.ConvertFromDatabaseEntity(x));
                //    modelEntity.Logs = new SortedList<int, Models.Log>(logs.ToDictionary(x => x.Order));
                //}
            }

            return modelEntity;
        }

        public TaskEntity ConvertFromModelEntity(Models.Bullet.Task modelEntity, bool deepConversion = true)
        {
            var databaseEntity = new TaskEntity
            {
                Id = modelEntity.Id,
                Description = modelEntity.Description,
                Signifier = modelEntity.Signifier,
                DateCreated = modelEntity.DateCreated,
                IsActive = modelEntity.IsActive,
                Status = modelEntity.Status,
                Order = modelEntity.Order,
                CreatedAt = modelEntity.CreatedAt,
                UpdatedAt = modelEntity.UpdatedAt,
            };

            if (deepConversion)
            {
                //if (modelEntity.Logs != null)
                //{
                //    var logs = modelEntity.Logs.Select(x => _logEntityConverter.ConvertFromModelEntity(x.Value));
                //    databaseEntity.Logs = new ObservableCollection<LogEntity>(logs);
                //}
            }

            return databaseEntity;
        }
    }


    public interface INoteEntityConverter : IEntityConverter<Note, NoteEntity> { }

    public class NoteEntityConverter : INoteEntityConverter
    {
        public Note ConvertFromDatabaseEntity(NoteEntity databaseEntity, bool deepConversion = true)
        {
            var modelEntity = new Note
            {
                Id = databaseEntity.Id,
                Description = databaseEntity.Description,
                Order = databaseEntity.Order,
                DateCreated = databaseEntity.DateCreated,
                Signifier = databaseEntity.Signifier,

                CreatedAt = databaseEntity.CreatedAt,
                UpdatedAt = databaseEntity.UpdatedAt,
            };

            if (deepConversion)
            {
                //if (databaseEntity.Logs != null)
                //{
                //    var logs = databaseEntity.Logs.Select(x => _logEntityConverter.ConvertFromDatabaseEntity(x));
                //    modelEntity.Logs = new SortedList<int, Models.Log>(logs.ToDictionary(x => x.Order));
                //}
            }

            return modelEntity;
        }

        public NoteEntity ConvertFromModelEntity(Note modelEntity, bool deepConversion = true)
        {
            var databaseEntity = new NoteEntity
            {
                Id = modelEntity.Id,
                Description = modelEntity.Description,
                Order = modelEntity.Order,
                DateCreated = modelEntity.DateCreated,
                Signifier = modelEntity.Signifier,

                CreatedAt = modelEntity.CreatedAt,
                UpdatedAt = modelEntity.UpdatedAt,
            };

            if (deepConversion)
            {
                //if (modelEntity.Logs != null)
                //{
                //    var logs = modelEntity.Logs.Select(x => _logEntityConverter.ConvertFromModelEntity(x.Value));
                //    databaseEntity.Logs = new ObservableCollection<LogEntity>(logs);
                //}
            }

            return databaseEntity;
        }
    }


    public interface IEventEntityConverter : IEntityConverter<Event, EventEntity> { }

    public class EventEntityConverter : IEventEntityConverter
    {
        public Event ConvertFromDatabaseEntity(EventEntity databaseEntity, bool deepConversion = true)
        {
            var modelEntity = new Event
            {
                Id = databaseEntity.Id,
                Description = databaseEntity.Description,
                Order = databaseEntity.Order,
                Date = databaseEntity.Date,
                DateCreated = databaseEntity.DateCreated,
                Duration = databaseEntity.Duration,
                Signifier = databaseEntity.Signifier,
                CreatedAt = databaseEntity.CreatedAt,
                UpdatedAt = databaseEntity.UpdatedAt,
            };

            if (deepConversion)
            {
                //if (modelEntity.Logs != null)
                //{
                //    var logs = modelEntity.Logs.Select(x => _logEntityConverter.ConvertFromModelEntity(x.Value));
                //    databaseEntity.Logs = new ObservableCollection<LogEntity>(logs);
                //}
            }

            return modelEntity;
        }

        public EventEntity ConvertFromModelEntity(Event modelEntity, bool deepConversion = true)
        {
            var databaseEntity = new EventEntity
            {
                Id = modelEntity.Id,
                Description = modelEntity.Description,
                Order = modelEntity.Order,
                Date = modelEntity.Date,
                DateCreated = modelEntity.DateCreated,
                Duration = modelEntity.Duration,
                Signifier = modelEntity.Signifier,
                CreatedAt = modelEntity.CreatedAt,
                UpdatedAt = modelEntity.UpdatedAt,
            };

            if (deepConversion)
            {
                //if (modelEntity.Logs != null)
                //{
                //    var logs = modelEntity.Logs.Select(x => _logEntityConverter.ConvertFromModelEntity(x.Value));
                //    databaseEntity.Logs = new ObservableCollection<LogEntity>(logs);
                //}
            }

            return databaseEntity;
        }
    }

    #endregion
}
