using System.ComponentModel.DataAnnotations;

namespace PetFinder.Models
{
    public class Breed
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public ICollection<Dog> Dogs { get; set; }
    }
}