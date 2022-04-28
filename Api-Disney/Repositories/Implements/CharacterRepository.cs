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

    public IQueryable<Character> GetQuery()
    {
        return _disneyContext.Characters.Include(a => a.Movies)
                                        .ThenInclude(a => a.Genres);
    }
    
}
