using gym_Api.Core.Contracts;
using gym_Api.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace gym_Api.Controllers
{
    [ApiController]
    [Route("/exercise")]
    public class ExerciseController : Controller
    {
        private readonly IExerciseService exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            this.exerciseService = exerciseService;
        }

        [HttpGet("allExercises")]
        public async Task<IActionResult> GetAllExercises()
        {
            var exercises = await exerciseService.GetAllExercisesAsync();

            return Ok(exercises);
        }

        [HttpPost("addSelectedExercise")]
        public async Task<IActionResult> AddSelectedExercise(ExerciseViewModel model)
        {

            var selectedExercise = await exerciseService.AddSelectedExerciseAsync(model);
            if (selectedExercise == null)
            {
                return Ok(new { message = "The selected Exercise already exist!" });
            }

            return Ok(selectedExercise);
        }

        [HttpGet("getSelectedVideos")]
        public async Task<IActionResult> GetSelectedVideos()
        {
            var videos = await exerciseService.GetSelectedVideosAsync();

            return Ok(videos);
        }

        [HttpPost("removeSelectedVideo")]
        public async Task<IActionResult> RemoveSelectedVideo([FromBody] int id)
        {

           var fileName = await exerciseService.RemoveSelectedItemAsync(id);
            if (string.IsNullOrEmpty(fileName))
            {
                return Ok(new { message = "Failed to remove the item. Please try againg later." });
            }

            return Ok(new {message = fileName});
        }
    }
}
