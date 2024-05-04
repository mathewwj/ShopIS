using System.Security.Claims;
using api.Dto.Account;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;

[Route("api/account")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ITokenService _tokenService;
    private readonly SignInManager<AppUser> _signInManager;


    public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _signInManager = signInManager;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var appUser = new AppUser
            {
                UserName = registerDto.Username,
                Email = registerDto.Email
            };

            var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);
            if (!createdUser.Succeeded) 
                return StatusCode(500, createdUser.Errors);
            
            var roleResult = await _userManager.AddToRoleAsync(appUser, nameof(UserRole.User));
            if (!roleResult.Succeeded)
                return StatusCode(500, roleResult.Errors);

            return Ok(new NewUserDto
            {
                Username = appUser.UserName,
                Email = appUser.Email,
                Token = _tokenService.CreateToken(appUser)
            });
        }
        catch(Exception ex)
        {
            return StatusCode(500, ex);
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        Console.WriteLine("aaa");
        var appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == loginDto.Username);
        if (appUser == null)
            return Unauthorized("Invalid credentials!");

        var result = await _signInManager.CheckPasswordSignInAsync(appUser, loginDto.Password, false);
        if (!result.Succeeded)
            return Unauthorized("Invalid credentials!");

        return Ok(new NewUserDto
        {
            Username = appUser.UserName,
            Email = appUser.Email,
            Token = _tokenService.CreateToken(appUser)
        });
    }
}