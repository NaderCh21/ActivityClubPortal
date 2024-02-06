using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity; // Add this for Identity
using ActivityClubPortal.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace ActivityClubPortal.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<Admin> _userManager;
        private readonly SignInManager<Admin> _signInManager;

        public AdminController(UserManager<Admin> userManager, SignInManager<Admin> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult> Authenticate([FromBody] AdminCredentials credentials)
        {
            if (credentials == null)
            {
                return BadRequest(new { Message = "Invalid credentials" });
            }

            var user = await _userManager.FindByNameAsync(credentials.Username);

            if (user != null && await _userManager.CheckPasswordAsync(user, credentials.Password))
            {
                await _signInManager.SignInAsync(user, isPersistent: false);

                return Ok(new { Message = "Authentication successful" });
            }

            return Unauthorized(new { Message = "Invalid username or password" });
        }

        [HttpPost("logout")]
        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return Ok(new { Message = "Logout successful" });
        }

        // Other methods for CRUD operations on Admin entities

    }
}
