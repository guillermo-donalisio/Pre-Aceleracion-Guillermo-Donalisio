using System.ComponentModel.DataAnnotations;

namespace Api_Disney.Models;

public class Character
{
        [Required]
        public int CharacterID {set;get;}
        public string? Image_url {set;get;}

        [MaxLength(30)]
        public string? Name {set;get;}
        public int Age {set;get;}
        public decimal Weight {set;get;}

        [MaxLength(150)]
        public string? Story {set;get;}
        
        // Collection navigation property 
        public List<MovieCharacter>? MovieCharacter { get; set; }
     
}
