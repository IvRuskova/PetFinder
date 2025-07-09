using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static PetFinder.Constants.DataConstants;

namespace PetFinder.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(FullNameLength)]
        public string FullName { get; set; }= string.Empty;
        public Owner? Owner { get; set; }
    }
}
