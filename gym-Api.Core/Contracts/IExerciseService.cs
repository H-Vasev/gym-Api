using gym_Api.Core.Models;
using gym_Api.Infrastructure.Data.Models;

namespace gym_Api.Core.Contracts
{
    public interface IExerciseService
    {
        public Task<ExerciseViewModel[]> GetAllExercisesAsync();

        public Task<ExerciseViewModel?> AddSelectedExerciseAsync(ExerciseViewModel model);

        public Task<SelectedExercise[]> GetSelectedVideosAsync();
    }
}
