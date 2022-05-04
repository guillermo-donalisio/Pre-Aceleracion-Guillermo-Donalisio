using Api_Disney.Models;

namespace Api_Disney.Services;

public interface IMovieService : IGenericService<Movie>
{
	IQueryable<Movie> GetMovieDetails();
	IQueryable<Movie> GetMovieByTitle(string title, int genreId, string orderBy);
}
