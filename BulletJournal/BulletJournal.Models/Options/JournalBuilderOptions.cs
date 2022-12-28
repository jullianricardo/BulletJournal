namespace BulletJournal.Models.Options
{
    public class JournalBuilderOptions
    {
        public bool BuildFutureLog { get; set; } = true;

        public bool BuildMonthlyLog { get; set; } = true;

        public bool BuildDailyLog { get; set; } = true;
    }
}
