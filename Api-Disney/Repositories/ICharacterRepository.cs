using System.Linq.Expressions;
using Api_Disney.Models;

namespace Api_Disney.Repositories;

public interface ICharacterRepository : IGenericRepository<Character>
{
	IQueryable<Character> GetQuery();
	IQueryable<Character> GetByName(string name, int age, decimal weight, int movieId);
}
