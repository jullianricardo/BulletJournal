using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Models.Collection
{
    public class UserDefinedLog : Collection
    {
        public override CollectionType Type => CollectionType.UserDefined;

        public override Topic ToTopic() => throw new NotImplementedException();
    }
}
