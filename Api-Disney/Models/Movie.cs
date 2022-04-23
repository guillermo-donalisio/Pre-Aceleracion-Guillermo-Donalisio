using System.ComponentModel.DataAnnotations;

namespace Api_Disney.Models;

public class Movie
{
        [Required]
        public int MovieID {set;get;}
        public string? Image_url {set;get;}

        [MaxLength(50)]
        public string? Title {set;get;}
        public DateTime Date_creation {set;get;}
        public int Rating {set;get;}  

        // Collection navigation property 
        public List<GenreMovie>? GenreMovie { get; set; }

        // Collection navigation property 
        public List<MovieCharacter>? MovieCharacter { get; set; }
      
}
