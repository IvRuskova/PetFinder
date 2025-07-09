using System.ComponentModel.DataAnnotations;

namespace PetFinder.Models
{
    public class ChipSearchLog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ChipNumberSearched { get; set; } = string.Empty;

        public DateTime SearchDate { get; set; } = DateTime.Now;

        public string ChipNumber { get; set; } = string.Empty;

        public string? IpAddress { get; set; }
    }
}
