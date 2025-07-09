using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PetFinder.Models
{
    [Comment("Breed Category")]
    public class Breed
    {
        [Key]
        [Comment("Breed Identifier")]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public ICollection<Dog>? Dogs { get; set; }
    }
}