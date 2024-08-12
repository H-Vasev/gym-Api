using gym_Api.Core.Models;
using gym_Api.Infrastructure.Data.Models;

namespace gym_Api.Core.Contracts
{
    public interface IExerciseService
    {
        public Task<ExerciseViewModel[]> GetAllExercisesAsync();

        public Task<SelectedExercise?> AddSelectedExerciseAsync(ExerciseViewModel model);

        public Task<SelectedExercise[]> GetSelectedVideosAsync();

        public Task<string> RemoveSelectedItemAsync(int id);
    }
}
