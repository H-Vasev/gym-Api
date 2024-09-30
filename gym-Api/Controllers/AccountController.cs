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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isExist = userManager.FindByEmailAsync(model.Email);
            if (isExist.Result != null)
            {
                return Ok($"A user with the email address: {model.Email} already exists.Please use a different email address.");
            }

            var accountUser = new IdentityUser()
            {
                UserName = model.Email,
                Email = model.Email,
            };

            var result = await userManager.CreateAsync(accountUser, model.Password);
            if (!result.Succeeded)
            {
                return BadRequest("Error occure during register!");
            }

            var token = GenerateJwtToken(accountUser);

            return Ok(new { Message = "Registration successful", Username = accountUser.Email, Token = token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> LogIn([FromBody] LogInViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return Ok("User with provided email do not exist!");
            }

            var result = await signInManager.CheckPasswordSignInAsync(user, model.Password, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                return Unauthorized("Invalid Password!");
            }

            var token = GenerateJwtToken(user);

            return Ok(new { message = "Login successfully!", userName = user.UserName, token = token });
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
