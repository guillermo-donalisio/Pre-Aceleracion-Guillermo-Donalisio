using Api_Disney.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Disney.Data;

public class DisneyContext : DbContext
{
    public DisneyContext(DbContextOptions<DisneyContext> options): base(options)
    {  
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("DisneyConnection");
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Fluent Api Configurations
        // Many-to-many relationship. Foreign keys as composite primary key in the joining table
        modelBuilder.Entity<MovieCharacter>().HasKey(mc => new {mc.CharacterID, mc.MovieID});
        modelBuilder.Entity<GenreMovie>().HasKey(gm => new {gm.GenreID, gm.MovieID});    

        // One-to-many relationship between the joining entity and other entities
        modelBuilder.Entity<MovieCharacter>()
            .HasOne(m => m.Movie)
            .WithMany(mc => mc.MovieCharacter)
            .HasForeignKey(m => m.MovieID);

        modelBuilder.Entity<MovieCharacter>()
            .HasOne(c => c.Character)
            .WithMany(mc => mc.MovieCharacter)
            .HasForeignKey(c => c.CharacterID);

        modelBuilder.Entity<GenreMovie>()
            .HasOne(g => g.Genre)
            .WithMany(gm => gm.GenreMovie)
            .HasForeignKey(g => g.GenreID); 
            
        modelBuilder.Entity<GenreMovie>()
            .HasOne(m => m.Movie)
            .WithMany(gm => gm.GenreMovie)
            .HasForeignKey(m => m.MovieID); 
            

        // Property Configurations
        modelBuilder.Entity<Character>()
                    .Property(c => c.Weight)
                    .HasPrecision(18, 2);
                  
    }

    public DbSet<Character>? Characters {set;get;}
    public DbSet<MovieCharacter>? MoviesCharacters {set;get;}
    public DbSet<Movie>? Movies {set;get;}
    public DbSet<GenreMovie>? GenresMovies {set;get;}
    public DbSet<Genre>? Genres {set;get;}

}
