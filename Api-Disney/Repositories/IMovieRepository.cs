using Api_Disney.Models;

namespace Api_Disney.Repositories;

public interface IMovieRepository : IGenericRepository<Movie>
{
	IQueryable<Movie> GetMovieDetails();
	IQueryable<Movie> GetMovieByTitle(string title, int genreId, string orderBy);


}
