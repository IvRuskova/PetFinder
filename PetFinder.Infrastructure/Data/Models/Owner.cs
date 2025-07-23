using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static PetFinder.Infrastructure.Constants.DataConstants;
namespace PetFinder.Infrastructure.Data.Models
{
    public class Owner
    {
        [Required]
        [Comment("Unique identifier for the owner.")]
        public int Id { get; set; }

        [Required]
        [StringLength(FullNameMaxLength)]
        [Comment("Full name for the owner.")]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }= string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(AddressMaxLength)]
        public string Address { get; set; } = string.Empty;

        //Navigation - one owner have many dogs
        public ICollection<Dog> Dogs { get; set; } = new List<Dog>();
    }
}
