using BulletJournal.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace BulletJournal.Models
{
    public class Journal : Entity
    {
        public bool IsDefault { get; set; }

        public string OwnerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Year { get; set; }

        public Index Index { get; set; }

        public List<Page> Pages { get; set; }

    }
}
