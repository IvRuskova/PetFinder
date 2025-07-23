using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static PetFinder.Infrastructure.Constants.DataConstants;
namespace PetFinder.Infrastructure.Data.Models
{
    public class Breed
    {
        [Key]
        [Comment("Unique identifier for the breed.")]
        public int Id { get; set; }

        [Required]
        [MaxLength(BreedNameMaxLength)]
        [Comment("Name of the breed.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Comment("Description of the breed.")]
        public ICollection<Dog> Dogs { get; set; } = new List<Dog>();
    }
}
