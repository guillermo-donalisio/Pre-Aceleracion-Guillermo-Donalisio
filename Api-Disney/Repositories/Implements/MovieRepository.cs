using Api_Disney.Data;
using Api_Disney.Models;

namespace Api_Disney.Repositories.Implements;

public class MovieRepository : GenericRepository<Movie>, IMovieRepository
{
    public MovieRepository(DisneyContext disneyContext) : base(disneyContext)
    {
    }
}
