using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static PetFinder.Constants.DataConstants;

namespace PetFinder.Models
{
    [Comment("Dog Category")]
    public class Dog
    {
        [Key]
        [Comment("Dog Identifier")]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(ChipNumberLength)]
        public string ChipNumber { get; set; } = string.Empty;

        public int Age { get; set; }

        public int BreedId { get; set; }
        public Breed? Breed { get; set; } 

        public int OwnerId { get; set; }
        public Owner? Owner { get; set; }

        public ICollection<VetReport> VetReports { get; set; } = new List<VetReport>();
    }
}
