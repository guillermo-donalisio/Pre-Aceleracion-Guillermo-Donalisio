using Microsoft.AspNetCore.Identity;

namespace Api_Disney.Models.Auth;

public class User : IdentityUser
{
    public bool? isActive {set;get;} //to avoid warnings I set up this as nullable property
}
