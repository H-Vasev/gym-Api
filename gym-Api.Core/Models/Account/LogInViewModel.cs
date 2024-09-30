using System.ComponentModel.DataAnnotations;

namespace gym_Api.Core.Models.Account
{
    public class LogInViewModel
    {
        [Required]
        public string Email { get; set; } = null!;


        [Required]
        public string Password { get; set; } = null!;
    }
}
