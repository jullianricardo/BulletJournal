using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Models.Collection
{
    public class ListCollection : Collection
    {
        public override CollectionType Type => CollectionType.List;

        public override Topic ToTopic() => throw new NotImplementedException();
    }
}
