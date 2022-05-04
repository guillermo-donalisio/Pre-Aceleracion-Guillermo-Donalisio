# Pre-Aceleracion-Guillermo-Donalisio
> Web Api to explore the world of Disney.

### Project Versions:
- Visual Studio Code: 1.66.2
- Net 6.0

**Packages NuGet installed:**
### To Authentications:
- Microsoft.AspNetCore.Authentication.JwtBearer (6.0.4)
- Microsoft.AspNetCore.Identity.EntityFrameworkCore (6.0.4)
- Microsoft.Extensions.Identity.Core (6.0.4)
### To Database Connections & LINQ queries:
- Microsoft.EntityFrameworkCore (6.0.4)
- SMicrosoft.EntityFrameworkCore.Design (6.0.4)
- Microsoft.EntityFrameworkCore.SqlServer (6.0.4)
- Microsoft.EntityFrameworkCore.Tools (6.0.4)
- System.Linq.Dynamic.Core (1.2.18)
### To use an email notification service:
- SendGrid (9.27.0)
### To consume the app:
- Swashbuckle.AspNetCore (6.2.3)
### To unit tests:
- Microsoft.NET.Test.Sdk (16.11.0)
- Moq (4.17.2)
- xunit (2.4.1)
- xunit.runner.visualstudio (2.4.3)
- coverlet.collector (3.1.0)
- FluentAssertions (6.6.0)
- Microsoft.EntityFrameworkCore.InMemory (6.0.4)

## Configurations

- Inside *appsetings.json* place your connection string, JWT ports and your ApiKey from SendGrid:
````
{
  "ConnectionStrings": {
    "DisneyConnection": "--- WRITE YOUR CONNECTION STRING HERE ---",
    "UserConnection": "--- WRITE YOUR CONNECTION STRING HERE ---"
  },  
  "JWT": {
    "ValidAudience": "--- WRITE YOUR PORT HERE ---",
    "ValidIssuer": "--- WRITE YOUR PORT HERE ---",
    "Secret": "--- SECRET KEY ---"
  },
  "SendGrid":{
    "ApiKey": "--- WRITE YOUR API KEY HERE ---"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
````
## Test your endpoints using Swagger at local host

````
https://localhost:7039/swagger/index.html
````



