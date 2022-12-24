using BulletJournal.Core.Common;
using BulletJournal.Models.Bullet;

namespace BulletJournal.Data.Model.Bullet
{
    public class NoteEntity : BulletEntity
    {
        public override Note ToModel(Models.Bullet.Bullet bullet)
        {
            var note = base.ToModel(bullet) as Note;
            return note;
        }

        public override NoteEntity FromModel(Models.Bullet.Bullet bullet, PrimaryKeyResolvingMap primaryKeyResolvingMap)
        {
            var noteEntity = base.FromModel(bullet, primaryKeyResolvingMap) as NoteEntity;
            return this;
        }

    }
}
