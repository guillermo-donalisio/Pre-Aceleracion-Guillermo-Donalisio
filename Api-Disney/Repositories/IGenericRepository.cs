using System.Linq.Expressions;

namespace Api_Disney.Repositories;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<List<TEntity>> GetAll();
	Task<TEntity> GetById(int id);
	Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
	Task<TEntity> Insert(TEntity entity);
	Task<TEntity> Update(TEntity entity);
	Task Delete(int id);
	IQueryable<TEntity> GetQueryable();
}
