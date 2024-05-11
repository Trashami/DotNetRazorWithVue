using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GeoJason.Web.Apis
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientSideVueAuthentication : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public ClientSideVueAuthentication(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet("IsLoggedIn")]
        public async Task<IActionResult> IsLoggedIn()
        {
            if (_signInManager.IsSignedIn(User))
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    return Ok(new
                    {
                        IsLoggedIn = true,
                        Username = user.UserName,
                        Email = user.Email
                    });
                }
            }
            return Ok(new { IsLoggedIn = false });
        }
    }
}
