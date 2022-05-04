using Api_Disney.Models;

namespace Api_Disney.Services;

public interface ICharacterService : IGenericService<Character>
{
	IQueryable<Character> GetCharacterDetails();
	IQueryable<Character> GetByName(string name, int age, decimal weight, int movieId);

}
