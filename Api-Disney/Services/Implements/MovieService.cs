using Api_Disney.Models;
using Api_Disney.Repositories;

namespace Api_Disney.Services.Implements;

public class MovieService : GenericService<Movie>, IMovieService
{
    private IMovieRepository _movieRepository;

    public MovieService(IMovieRepository movieRepository) : base(movieRepository)
    {
        this._movieRepository = movieRepository;
    }

    public IQueryable<Movie> GetMovieByTitle(string title, int genreId, string orderBy)
    {
        return _movieRepository.GetMovieByTitle(title, genreId, orderBy);
    }

    public IQueryable<Movie> GetMovieDetails()
    {
        return _movieRepository.GetMovieDetails();
    }
}
