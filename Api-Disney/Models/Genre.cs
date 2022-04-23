using System.ComponentModel.DataAnnotations;

namespace Api_Disney.Models;

public class Genre
{
        [Required]
        public int GenreID {set;get;}

        [MaxLength(30)]
        public string? Name {set;get;}
        public string? Image_url {set;get;}   

        // Collection navigation property
        public List<GenreMovie>? GenreMovie { get; set; }
       
}
