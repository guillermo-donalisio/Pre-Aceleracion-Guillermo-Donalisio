using Api_Disney.Data;
using Api_Disney.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Api_Disney.Repositories.Implements;

public class MovieRepository : GenericRepository<Movie>, IMovieRepository
{
    private DisneyContext _disneyContext;
    public MovieRepository(DisneyContext disneyContext) : base(disneyContext)
    {
        this._disneyContext = disneyContext;
    }

    public IQueryable<Movie> GetMovieByTitle(string title, int genreId, string orderBy)
    {
        var sort = orderBy == "asc" ? "ascending" : "descending";
        var query = _disneyContext.Movies
            .Include(x => x.Characters)                    
            .Include(g => g.Genres)
                .Where(x => x.Title.Contains(title) || x.Genres.Any(g => g.GenreID == genreId))
                //.Where(x => x.Title == title || x.Genres.Any(g => g.GenreID == genreId)) 
                .OrderBy($"Date_creation {sort}") // From Dynamic LINQ library
                    .Select(c => new Movie{
                        Image_url = c.Image_url,
                        Title = c.Title,
                        Date_creation = c.Date_creation,
                        Rating = c.Rating,
                        Genres = c.Genres,
                    });

        return query; 
    }

    public IQueryable<Movie> GetMovieDetails()
    {
        return _disneyContext.Movies.Include(a => a.Characters)
                                    .Include(a => a.Genres);
    }

    
}
