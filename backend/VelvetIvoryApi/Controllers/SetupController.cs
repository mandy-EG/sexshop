using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VelvetIvoryApi.Models;
using VelvetIvoryApi.Dtos;

namespace VelvetIvoryApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SetupController : ControllerBase
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<AppUser> _userManager;

    public SetupController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }

    [HttpPost("roles")]
    public async Task<IActionResult> CreateRoles()
    {
        var roles = new[] { "Admin", "Customer" };
        foreach (var role in roles)
        {
            if (!await _roleManager.RoleExistsAsync(role))
            {
                await _roleManager.CreateAsync(new IdentityRole(role));
            }
        }
        return Ok("Roles ensured");
    }

    [HttpPost("admin/{email}")]
    public async Task<IActionResult> MakeAdmin(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null) return NotFound("User not found");

        if (!await _roleManager.RoleExistsAsync("Admin"))
        {
            await _roleManager.CreateAsync(new IdentityRole("Admin"));
        }

        if (!await _userManager.IsInRoleAsync(user, "Admin"))
        {
            await _userManager.AddToRoleAsync(user, "Admin");
        }

        return Ok($"User {email} is now an Admin");
    }

    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword([FromBody] LoginDto model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null) return NotFound("User not found");

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var result = await _userManager.ResetPasswordAsync(user, token, model.Password);

        if (result.Succeeded)
            return Ok($"Password for {model.Email} has been reset to: {model.Password}");
            
        return BadRequest(result.Errors);
    }

    [HttpGet("roles/{email}")]
    public async Task<IActionResult> GetUserRoles(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null) return NotFound("User not found");
        
        var roles = await _userManager.GetRolesAsync(user);
        return Ok(new { Email = user.Email, Roles = roles });
    }
}
