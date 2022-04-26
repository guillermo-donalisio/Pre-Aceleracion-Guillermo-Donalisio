using System.Linq;
using System.Linq.Expressions;
using Api_Disney.Data;
using Api_Disney.Models;
using Api_Disney.ViewModels.CRUD.Characters;

namespace Api_Disney.Repositories.Implements;

public class CharacterRepository : GenericRepository<Character>, ICharacterRepository
{
    public CharacterRepository(DisneyContext disneyContext) : base(disneyContext)
    {
    }
}
