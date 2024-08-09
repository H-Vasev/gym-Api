using gym_Api.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace gym_Api.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Exercise> Exercises { get; set; } = null!;
    }
}
