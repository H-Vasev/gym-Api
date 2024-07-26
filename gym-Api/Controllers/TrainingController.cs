using gym_Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace gym_Api.Controllers
{
    [ApiController]
    [Route("/")]
    public class TrainingController : Controller
    {
        [HttpGet("training")]
        public IActionResult GetVideos()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","videos");
            var videosFiles = Directory.GetFiles(filePath, "*.mp4");

            var videos = new List<VideoFile>();

            foreach (var video in videosFiles)
            {
                var fileName = Path.GetFileName(video);
                var videoUrl = $"https://localhost:7010/videos/{fileName}";
                videos.Add(new VideoFile()
                {
                    FileName = fileName,
                    Url = videoUrl
                });
            }

            return Ok(videos);
        }
    }
}
