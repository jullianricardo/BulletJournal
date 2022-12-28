using BulletJournal.Models;
using BulletJournal.Models.Options;

namespace BulletJournal.Core.Services.Builders
{
    public interface IJournalBuilder
    {
        Journal BuildJournal(Journal journal, JournalBuilderOptions builderOptions);
    }
}
