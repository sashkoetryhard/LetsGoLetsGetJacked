using System.ComponentModel.DataAnnotations;

namespace LetsGoLetsGetJacked.Models
{
    public class WorkoutSession
    {
        public int Id { get; set; }
        [Required]
        [StringLength(75)]
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Today;
        public string? UserId { get; set; }
        public List<WorkoutSet> Sets { get; set; } = new List<WorkoutSet>();
    }
}
