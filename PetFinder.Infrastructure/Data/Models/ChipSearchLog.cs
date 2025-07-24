using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static PetFinder.Infrastructure.Constants.DataConstants;

namespace PetFinder.Infrastructure.Data.Models
{
    public class ChipSearchLog
    {
        [Key]
        [Required]
        [Comment("Unique identifier for the chip search log entry.")]
        public int Id { get; set; }

        [Required]
        [MaxLength(ChipNumberMaxLength)]
        [Comment("The chip number that was searched for.")]
        public string ChipNumberSearched { get; set; } = string.Empty;

        [Required]
        [Comment("The date and time when the chip search was performed.")]
        [DataType(DataType.DateTime)]
        public DateTime SearchDate { get; set; } = DateTime.Now;

        [Required]
        [MaxLength(ChipNumberMaxLength)]
        [Comment("The chip number of the dog that was found during the search.")]
        public string ChipNumber { get; set; } = string.Empty;

        [Required]
        [Comment("The IP number.")]
        public string IP { get; set; }
    }
}
