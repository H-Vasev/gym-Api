namespace gym_Api.Core.Models
{
    public class ExerciseViewModel
    {
        public int Id { get; set; }

        public string FileName { get; set; } = null!;

        public string Url { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int Duration { get; set; }
    }
}
