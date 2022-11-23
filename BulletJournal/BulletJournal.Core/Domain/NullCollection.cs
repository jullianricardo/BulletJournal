using System.Collections.ObjectModel;

namespace BulletJournal.Core.Domain
{

    //User for mark that collection is null (not initialized) used in patch operation
    public class NullCollection<T> : ObservableCollection<T>
    {

    }
}
