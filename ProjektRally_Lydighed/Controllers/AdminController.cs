using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjektRally_Lydighed.Areas.Identity.Data;

namespace ProjektRally_Lydighed.Controllers
{


    public class AdminController : Controller
    {
        private readonly UserManager<ProjektRally_Lydighed1> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(UserManager<ProjektRally_Lydighed1> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> AssignAdminRole(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email is required");
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound($"User with email {email} not found.");
            }

            if (!await _roleManager.RoleExistsAsync("Administrator"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Administrator"));
            }

            var result = await _userManager.AddToRoleAsync(user, "Administrator");
            if (result.Succeeded)
            {
                return Ok($"User {email} has been assigned the Administrator role.");
            }
            else
            {
                return BadRequest("Failed to assign role.");
            }
        }
    }
}
