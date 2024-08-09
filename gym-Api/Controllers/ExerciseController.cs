using gym_Api.Core.Contracts;
using gym_Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;

namespace gym_Api.Controllers
{
    [ApiController]
    [Route("/")]
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

        [HttpPost("selectVideo")]
        public IActionResult SaveAsSelected(VideoFile videoData)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "SelectedVideos", "videosData.json");

            List<VideoFile> videos;

            if (System.IO.File.Exists(path))
            {
                var existingData = System.IO.File.ReadAllText(path);
                videos = JsonSerializer.Deserialize<List<VideoFile>>(existingData) ?? new List<VideoFile>();
            }
            else
            {
                videos = new List<VideoFile>();
            }

            if (!videos.Any(i => i.FileName == videoData.FileName))
            {
                videos.Add(videoData);

                var jsonData = JsonSerializer.Serialize(videos);
                System.IO.File.WriteAllText(path, jsonData);
            }
            else
            {
                return Ok(new { message = "The selected video already exist!" });
            }

            return Ok(videoData);
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
