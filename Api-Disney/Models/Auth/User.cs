using Microsoft.AspNetCore.Identity;

namespace Api_Disney.Models.Auth;

public class User : IdentityUser
{
    public bool isActive {set;get;} 
}

//to avoid warnings I set up the property bool as as nullable property (bool?) to create the database

/* Warning: The 'bool' property 'isActive' on entity type 'User' is configured with a database-generated default. 
This default will always be used for inserts when the property has the value 'false', 
since this is the CLR default for the 'bool' type. Consider using the nullable 'bool?' type instead, 
so that the default will only be used for inserts when the property value is 'null'. */