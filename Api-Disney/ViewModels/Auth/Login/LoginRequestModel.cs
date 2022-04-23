using System.ComponentModel.DataAnnotations;

namespace Api_Disney.ViewModels.Auth.Login;

public class LoginRequestModel
{
    [Required]
	[MinLength(6)]
	public string? Username {set;get;} //to avoid warnings I set up this as nullable property
    
	[Required]
	[MinLength(6)]
	public string? Password {set;get;}
}
