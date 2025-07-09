using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static PetFinder.Constants.DataConstants;

namespace PetFinder.Models
{
    [Comment("Owner category")]
    public class Owner
    {
        [Key]
        [Comment("Owner Identifier")]
        public int Id { get; set; }

        [Required]
        [StringLength(FullNameLength)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(AdressLength)]
        public string Address { get; set; } = string.Empty;

        //Navigation - one owner have many dogs
        public ICollection<Dog> Dogs { get; set; } = new List<Dog>();
    }
}