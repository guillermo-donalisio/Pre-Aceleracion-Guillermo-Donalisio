namespace Api_Disney.ViewModels.CRUD.Movie;

public class UpdateMovieDTO
{
    public int movieID {set;get;}
    public string image_url {set;get;}
    public string title {set;get;}
    public DateTime date_creation {set;get;}
    public int rating {set;get;}
}
