

using gym_Api.Core.Contracts;
using gym_Api.Core.Models;
using gym_Api.Infrastructure.Data;
using gym_Api.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace gym_Api.Core.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly ApplicationDbContext dbContext;

        public ExerciseService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
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
    }
}
