using Api_Disney.Data;
using Api_Disney.Models;

namespace Api_Disney.Repositories.Implements;

public class CharacterRepository : GenericRepository<Character>, ICharacterRepository
{
    public CharacterRepository(DisneyContext disneyContext) : base(disneyContext)
    {
    }
}
