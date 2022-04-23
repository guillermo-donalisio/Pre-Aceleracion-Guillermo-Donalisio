using System.ComponentModel.DataAnnotations;

namespace Api_Disney.Models;

// Many to many Relationships
public class GenreMovie
{
    // Composite primary key
    // reference fk_genre
    // reference fk_movie
    [Required]
    public int GenreID {set;get;}    
    public Genre? Genre {set;get;}
    
    [Required]
    public int MovieID {set;get;}
    public Movie? Movie {set;get;}
}
