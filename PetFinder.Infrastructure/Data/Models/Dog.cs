using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PetFinder.Infrastructure.Constants.DataConstants;
namespace PetFinder.Infrastructure.Data.Models
{
    [Comment("Represents a dog entity in the system.")]
    public class Dog
    {
        [Key]
        [Comment("Unique identifier for the dog.")]
        public int Id { get; set; }

        [Required]
        [MaxLength(DogNameMaxLength)]
        [Comment("Name of the dog.")]
        public string Name { get; set; }= string.Empty;

        [Required]
        [MaxLength(ChipNumberMaxLength)]
        [Comment("Unique chip number for the dog.")]
        public string ChipNumber { get; set; } = string.Empty;

        [Comment("Dog age.")]
        public int Age { get; set; }

        [Required]
        [Comment("Dog breed identifier.")]
        public int BreedId { get; set; }
        
        [ForeignKey(nameof(OwnerId))]
        public Breed Breed { get; set; } = null!;

        [Required]
        [Comment("Owner identifier.")]
        public int OwnerId { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public Owner Owner { get; set; } = null!;
    }
}
