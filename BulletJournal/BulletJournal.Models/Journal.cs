using BulletJournal.Models.Collection;
using BulletJournal.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace BulletJournal.Models
{
    public class Journal : Entity
    {
        public Journal()
        {
            Spreads = new SortedList<int, Spread>();
        }

        public bool IsDefault { get; set; }

        public string OwnerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Year { get; set; }

        public Index Index { get; set; }

        public SortedList<int, Spread> Spreads { get; set; }
    }
}
