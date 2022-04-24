using Api_Disney.Models;
using Api_Disney.Repositories;

namespace Api_Disney.Services.Implements;

public class CharacterService : GenericService<Character>, ICharacterService
{
    private ICharacterRepository _characterRepository;
    
    public CharacterService(ICharacterRepository characterRepository) : base(characterRepository)
    {
        this._characterRepository = characterRepository;
    }
}
