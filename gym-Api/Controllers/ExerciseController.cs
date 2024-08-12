using gym_Api.Core.Contracts;
using gym_Api.Core.Models;
using gym_Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;

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

            return Ok(model);
        }

        [HttpGet("getSelectedVideos")]
        public async Task<IActionResult> GetSelectedVideos()
        {
            var videos = await exerciseService.GetSelectedVideosAsync();

            return Ok(videos);
        }

        [HttpGet("selectedVideos")]
        public IActionResult GetSelectetVideos()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "SelectedVideos", "videosData.json");

            var videosPath = System.IO.File.ReadAllText(path);
            var videos = JsonSerializer.Deserialize<List<VideoFile>>(videosPath) ?? new List<VideoFile>();


            return Ok(new { selectedVideos = videos });
        }


        [HttpPost("removeSelectedVideo")]
        public IActionResult RemoveSelectedVideo(VideoFile file)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "SelectedVideos", "videosData.json");

            var videosPath = System.IO.File.ReadAllText(path);

            var videos = JsonSerializer.Deserialize<List<VideoFile>>(videosPath);

            if (videos != null && videos.Any(v => v.FileName == file.FileName))
            {
                var itemToRemove = videos.FirstOrDefault(item => item.FileName == file.FileName);
                videos.Remove(itemToRemove!);

                var serializedVideos = JsonSerializer.Serialize(videos);
                System.IO.File.WriteAllText(path, serializedVideos);

                return Ok(new { message = file.FileName });
            }

            return Ok(new { message = "The selected video does not exist!" });
        }
    }
}
