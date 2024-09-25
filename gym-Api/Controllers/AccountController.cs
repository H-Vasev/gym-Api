using gym_Api.Core.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace gym_Api.Controllers
{
    [ApiController]
    [Route("/")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private IConfiguration configuration;

        public AccountController(
            UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager,
            IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if(string.IsNullOrWhiteSpace(model.Email))
            {
                return BadRequest();
            }

            if(model.Password != model.ConfirmPassword)
            {
                return BadRequest();
            }

            var isExist = userManager.FindByEmailAsync(model.Email);
            if (isExist.Result != null)
            {
                return BadRequest($"A user with the email address: {model.Email} already exists.Please use a different email address.");
            }

            var accountUser = new IdentityUser()
            {
                UserName = model.Email,
                Email = model.Email,
            };

            var result = await userManager.CreateAsync(accountUser, model.Password);
            if (result.Succeeded) 
            {
                await signInManager.SignInAsync(accountUser, isPersistent: false);

                var token = GenerateJwtToken(accountUser);

                return Ok(new {Result = "Registration successful", Token = token});
            }

            return BadRequest();
        }

        private string GenerateJwtToken(IdentityUser accountUser)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, accountUser.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                       claims: claims,
                       expires: DateTime.Now.AddMinutes(30),
                       signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
