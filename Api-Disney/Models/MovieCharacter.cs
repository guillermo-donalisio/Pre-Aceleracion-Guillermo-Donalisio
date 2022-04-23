using System.ComponentModel.DataAnnotations;

namespace Api_Disney.Models;

// Many to many Relationships
public class MovieCharacter
{
    // Composite primary key
    // reference fk_character
    // reference fk_movie

    [Required]
    public int CharacterID {set;get;}
    public Character? Character {set;get;}

    [Required]
    public int MovieID {set;get;}
    public Movie? Movie {set;get;}
}
