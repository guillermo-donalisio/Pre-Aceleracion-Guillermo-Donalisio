using System.ComponentModel.DataAnnotations;

namespace Api_Disney.ViewModels.Auth.Register;

public class RegisterRequestModel
{
    [Required]
	[MinLength(6)]
    public string? Username {set;get;} //to avoid warnings I set up this as nullable property

	[Required]
	[EmailAddress]
	public string? Email {set;get;}

	[Required]
	[MinLength(6)]
	public string? Password {set;get;}
}
