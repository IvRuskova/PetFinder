using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PetFinder.Models
{
    public class VetReport
    {
        [Comment("Veterinary Reports Identifier")]
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;

        public DateTime Date { get; set; } = DateTime.Now;

        public string ReporterName { get; set; } = string.Empty;

        public int DogId { get; set; }
        public Dog? Dog { get; set; }
    }
}