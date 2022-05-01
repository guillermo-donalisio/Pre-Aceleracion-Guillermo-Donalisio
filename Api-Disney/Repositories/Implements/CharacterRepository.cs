using System.Net.Mime;
using System.Linq;
using System.Linq.Expressions;
using Api_Disney.Data;
using Api_Disney.Models;
using Api_Disney.ViewModels.CRUD.Characters;
using Microsoft.EntityFrameworkCore;

namespace Api_Disney.Repositories.Implements;

public class CharacterRepository : GenericRepository<Character>, ICharacterRepository
{
    private DisneyContext _disneyContext;

    public CharacterRepository(DisneyContext disneyContext) : base(disneyContext)
    {
        this._disneyContext = disneyContext;   
    }

    public IQueryable<Character> GetCharacterDetails()
    {
        return _disneyContext.Characters.Include(a => a.Movies)
                                            .ThenInclude(a => a.Genres);
    }    
   
    public IQueryable<Character> GetByName(string name, int age, decimal weight, int movieId)
    {  
        var query = _disneyContext.Characters
            .Include(x => x.Movies)                    
                .ThenInclude(g => g.Genres)
                    .Where(x => x.Name.Contains(name) || x.Age == age 
                            || x.Weight == weight 
                            || x.Movies.Any(i => i.MovieID == movieId)) 
                                .Select(c => new Character{
                                    Image_url = c.Image_url,
                                    Name = c.Name,
                                    Age = c.Age,
                                    Weight = c.Weight,
                                    Story = c.Story,
                                    Movies = c.Movies
                                });

        return query;          
    }

   
}
