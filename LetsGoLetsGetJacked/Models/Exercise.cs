using System.ComponentModel.DataAnnotations;
namespace LetsGoLetsGetJacked.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        [Required]
        [StringLength(75), MinLength(2)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(30)]
        public string MuscleGroup { get; set; } = string.Empty;
    }
}
