using System.ComponentModel.DataAnnotations;

namespace PetFinder.Models
{
    public class Owner
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Address { get; set; } = string.Empty;

        //Navigation - one owner have many dogs
        public ICollection<Dog> Dogs { get; set; } = new List<Dog>();
    }
}