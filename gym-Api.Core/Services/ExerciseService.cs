

using gym_Api.Core.Contracts;
using gym_Api.Core.Models;
using gym_Api.Infrastructure.Data;
using gym_Api.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace gym_Api.Core.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly ApplicationDbContext dbContext;

        public ExerciseService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<SelectedExercise?> AddSelectedExerciseAsync(ExerciseViewModel model)
        {

            var isExist = await dbContext.SelectedExercises
                .AnyAsync(e => e.FileName == model.FileName);


            if (!isExist)
            {
                var exerciseToAdd = new SelectedExercise()
                {
                    FileName = model.FileName,
                    Description = model.Description,
                    Duration = model.Duration,
                    Url = model.Url,
                };

                await dbContext.SelectedExercises.AddAsync(exerciseToAdd);
                await dbContext.SaveChangesAsync();

                return exerciseToAdd;
            }


            return null;
        }

        public async Task<ExerciseViewModel[]> GetAllExercisesAsync()
        {
            var exercises = await dbContext.Exercises
                .AsNoTracking()
                .Select(e => new ExerciseViewModel
                {
                    Id = e.Id,
                    FileName = e.FileName,
                    Url = e.Url,
                    Description = e.Description,
                    Duration = e.Duration,
                }).ToArrayAsync();

            return exercises;
        }

        public async Task<SelectedExercise[]> GetSelectedVideosAsync()
        {
            var selectedExercises = await dbContext.SelectedExercises
                .AsNoTracking()
                .Select(e => new SelectedExercise()
                {
                    Id = e.Id,
                    FileName = e.FileName,
                    Url = e.Url,
                    Description = e.Description,
                    Duration = e.Duration,
                }).ToArrayAsync();

            return selectedExercises;
        }


        public async Task<string> RemoveSelectedItemAsync(int id)
        {
            var itemToRemove = await dbContext.SelectedExercises
                .FirstOrDefaultAsync(i => i.Id == id);

            if(itemToRemove != null)
            {
                dbContext.SelectedExercises.Remove(itemToRemove);  
                await dbContext.SaveChangesAsync(); 

                return itemToRemove.FileName;
            }

            return "";
        }
    }
}
