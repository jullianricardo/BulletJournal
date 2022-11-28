using System;
using System.Collections.Generic;
using System.Text;

namespace BulletJournal.Models.Bullet
{
    public class Note : Bullet
    {
        public override BulletType BulletType => BulletType.Note;
    }
}
