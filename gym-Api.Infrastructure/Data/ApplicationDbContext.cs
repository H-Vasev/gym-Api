using gym_Api.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace gym_Api.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
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

        public DbSet<SelectedExercise> SelectedExercises { get; set; } = null!;
    }
}
