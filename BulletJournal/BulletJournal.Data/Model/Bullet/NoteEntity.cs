using BulletJournal.Models.Bullet;

namespace BulletJournal.Data.Model.Bullet
{
    public class NoteEntity : BulletEntity
    {
        public override BulletType Type
        {
            get { return BulletType.Note; }
            set { }
        }
    }
}
