using System.ComponentModel.DataAnnotations;

namespace LetsGoLetsGetJacked.Models
{
    public class WorkoutSet
    {
        public int Id { get; set; }
        public int WorkoutSessionId { get; set; }
        public int ExerciseId { get; set; }
        [Range(0.5, 1000)]
        public double Weight { get; set; }
        [Range(1, 50)]
        public int Reps { get; set; }
        [Range(1, 50)]
        public int SetNumber { get; set; }
        public WorkoutSession? WorkoutSession { get; set; }
        public Exercise? Exercise { get; set; }
    }
}
