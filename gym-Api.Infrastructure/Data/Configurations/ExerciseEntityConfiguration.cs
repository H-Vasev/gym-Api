using gym_Api.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym_Api.Infrastructure.Data.Configurations
{
    public class ExerciseEntityConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.HasData(GenerateExercise());
        }

        private Exercise[] GenerateExercise()
        {
            return new Exercise[]
            {
                    new Exercise { Id = 1, FileName = "video-01", Url= "/videos/video-01.mp4", Description= "Seconds", Duration= 30},
                    new Exercise { Id = 2, FileName = "video-02", Url= "/videos/video-02.mp4", Description = "Seconds", Duration = 30},
                    new Exercise { Id = 3, FileName = "video-03", Url= "/videos/video-03.mp4", Description = "Times", Duration = 30 },
                    new Exercise { Id = 4, FileName = "video-04", Url= "/videos/video-04.mp4", Description = "Seconds", Duration = 30 },
                    new Exercise { Id = 5, FileName = "video-05", Url= "/videos/video-05.mp4", Description = "Times", Duration = 30 },
                    new Exercise { Id = 6, FileName = "video-06", Url= "/videos/video-06.mp4", Description = "Seconds", Duration = 30 },
                    new Exercise { Id = 7, FileName = "video-07", Url= "/videos/video-07.mp4", Description = "Seconds", Duration = 30 },
                    new Exercise { Id = 8, FileName = "video-08", Url= "/videos/video-08.mp4", Description = "Seconds", Duration = 30 },
                    new Exercise { Id = 9, FileName = "video-09", Url= "/videos/video-09.mp4", Description = "Seconds", Duration = 30 },
                    new Exercise { Id = 10, FileName = "video-10", Url= "/videos/video-10.mp4", Description = "Seconds", Duration = 30 },
                    new Exercise { Id = 11, FileName = "video-11", Url= "/videos/video-11.mp4", Description = "Seconds", Duration = 30 },
                    new Exercise { Id = 12, FileName = "video-12", Url= "/videos/video-12.mp4", Description = "Seconds", Duration = 30 },
                    new Exercise { Id = 13, FileName = "video-13", Url= "/videos/video-13.mp4", Description = "Seconds", Duration = 30 },
                    new Exercise { Id = 14, FileName = "video-14", Url= "/videos/video-14.mp4", Description = "Seconds", Duration = 30 },
                    new Exercise { Id = 15, FileName = "video-15", Url= "/videos/video-15.mp4", Description = "Seconds", Duration = 30 },
                    new Exercise { Id = 16, FileName = "video-16", Url= "/videos/video-16.mp4", Description = "Seconds", Duration = 30 }
            };
        }
    }
}
