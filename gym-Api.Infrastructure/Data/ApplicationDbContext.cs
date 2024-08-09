using gym_Api.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace gym_Api.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           var assembley = Assembly.GetAssembly(typeof(ApplicationDbContext)) ?? 
                           Assembly.GetExecutingAssembly();
            modelBuilder.ApplyConfigurationsFromAssembly(assembley);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Exercise> Exercises { get; set; } = null!;
    }
}
