namespace Api_Disney.ViewModels.Auth.Login;

public class LoginResponseModel
{
    public string? Token {set;get;} //to avoid warnings I set up this as nullable property
	public DateTime ValidTo {set;get;}
}
