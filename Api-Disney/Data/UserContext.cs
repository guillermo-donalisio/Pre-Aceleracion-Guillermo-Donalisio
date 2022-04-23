using Api_Disney.Models.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Api_Disney.Data;

public class UserContext : IdentityDbContext<User>
{
    private const string Schema = "users";
    public UserContext(DbContextOptions<UserContext> options): base(options)
    {  
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {      
        base.OnModelCreating(modelBuilder);
	    modelBuilder.HasDefaultSchema(Schema);  

        // Property Configurations
        modelBuilder.Entity<User>()
            .Property(x => x.isActive)
            .HasDefaultValue(true); 
    }
}
