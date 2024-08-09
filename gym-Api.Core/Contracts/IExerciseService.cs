using gym_Api.Core.Models;

namespace gym_Api.Core.Contracts
{
    public interface IExerciseService
    {
        public Task<ExerciseViewModel[]> GetAllExercisesAsync();

        public Task<ExerciseViewModel?> AddSelectedExerciseAsync(ExerciseViewModel model);
    }
}
