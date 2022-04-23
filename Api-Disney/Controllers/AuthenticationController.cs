using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using Api_Disney.Models.Auth;
using Api_Disney.ViewModels.Auth.Login;
using Api_Disney.ViewModels.Auth.Register;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Api_Disney.Controllers;

[ApiController]
public class AuthenticationController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IConfiguration _configuration;

    public AuthenticationController
        (UserManager<User> userManager, 
        SignInManager<User> signInManager, 
        IConfiguration configuration)
    {
        this._userManager = userManager;
        this._signInManager = signInManager;
        this._configuration = configuration;
    }

    // Register
    [HttpPost]
    [Route ("auth/register")]
    public async Task<IActionResult> Register(RegisterRequestModel model)
    {
        var userExists = await _userManager.FindByNameAsync(model.Username);

        if(userExists != null)
        {
			return StatusCode(StatusCodes.Status400BadRequest);
        }

        var user = new User
        {
            UserName = model.Username,
            Email = model.Email
        };

        var result = await _userManager.CreateAsync(user, model.Password);

        if(!result.Succeeded)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                Status = "Error",
                Message = $"User Creation Failed! Errors: {string.Join(", ", result.Errors.Select(x => x.Description))}"
            });
        }
        
        return Ok(new 
        {
            Status = "Success",
			Message = "User Creation Successfully!"
        });
    }

    // Login
    [HttpPost]
    [Route ("auth/login")]
    public async Task<IActionResult> Login(LoginRequestModel model)
    {
        var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);

        if(result.Succeeded)
        {
            var currentUser = await _userManager.FindByNameAsync(model.Username);
            if(currentUser.isActive)
            {
                return Ok(await GetToken(currentUser));
            }
        }

        return StatusCode(StatusCodes.Status401Unauthorized, new
        {
            Status = "Error",
            Message = $"El usuario {model.Username} no esta autorizado!"
        });
    }

    private async Task<LoginResponseModel> GetToken(User currentUser)
	{
		try
		{
			var userRoles = await _userManager.GetRolesAsync(currentUser);

			var authClaims = new List<Claim>()
			{
				new Claim(ClaimTypes.Name, currentUser.UserName),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
			};
			
			authClaims.AddRange(userRoles.Select(x => new Claim(ClaimTypes.Role, x)));

			var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
			
			var token = new JwtSecurityToken
			(
				issuer: _configuration["JWT:ValidIssuer"],
				audience: _configuration["JWT:ValidAudience"],
				expires: DateTime.Now.AddHours(1),
				claims: authClaims,
				signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
			);

			return new LoginResponseModel
			{
				Token = new JwtSecurityTokenHandler().WriteToken(token),
				ValidTo = token.ValidTo
			};
			
		}
		catch (System.Exception ex)
		{
			throw new Exception(ex.Message);			
		}
	} 
}
