using System.ComponentModel.DataAnnotations;

namespace PetFinder.Models
{
    public class Dog
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(15)]
        public string ChipNumber { get; set; } = string.Empty;

        public int Age { get; set; }

        public int BreedId { get; set; }
        public Breed? Breed { get; set; } 

        public int OwnerId { get; set; }
        public Owner? Owner { get; set; }
    }
}
