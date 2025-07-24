using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PetFinder.Infrastructure.Constants.DataConstants;

namespace PetFinder.Infrastructure.Data.Models
{
    public class VetReport
    {
        [Required]
        [Comment("Veterinary Reports Identifier")]
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        [Comment("Description of the veterinary report.")]
        public string Description { get; set; } = string.Empty;

        [Comment("Date of the veterinary report.")]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required]
        [MaxLength(ReporterNameMaxLength)]
        [Comment("Name of the person who reported the veterinary issue.")]
        public string ReporterName { get; set; } = string.Empty;

        [Required]

        [Comment("Identifier for the dog associated with the veterinary report.")]
        public int DogId { get; set; }

        [ForeignKey(nameof(DogId))]
        public Dog Dog { get; set; } = null!;
    }
}
