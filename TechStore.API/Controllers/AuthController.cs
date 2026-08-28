using TechStore.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TechStore.API.DTOs;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography.X509Certificates;
namespace TechStore.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
    

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterRequest request)
        {
            if (request.Password != request.ConfirmPassword)
            {
                return BadRequest("Passwords do not match.");
            }

            var user = new ApplicationUser
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                UserName = request.Email,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
                City = request.City,
                PostalCode = request.PostalCode,
                Country = request.Country,
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            await _userManager.AddToRoleAsync(user, "User");
            
            return Ok("User registered successfully.");
          
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
               if (user == null)
            {
                return Unauthorized("Invalid email or password.");
            }
            var loginResult = await _signInManager.PasswordSignInAsync(user, request.Password, isPersistent: request.RememberMe, lockoutOnFailure: true);
            if (loginResult.IsLockedOut)
            {
                return Unauthorized("Account is locked due to multiple failed login attempts.");
            }
            if (!loginResult.Succeeded)
            {
                return Unauthorized("Invalid email or password.");
            }

            return Ok("User logged in successfully.");
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok("User logged out successfully.");
        }

    }
}
