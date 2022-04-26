using System.Linq.Expressions;
using Api_Disney.Repositories;

namespace Api_Disney.Services.Implements;

public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
{
    private IGenericRepository<TEntity> _genericRepository;

    public GenericService(IGenericRepository<TEntity> genericRepository)
    {
        this._genericRepository = genericRepository;
    }

    public IQueryable<TEntity> GetQueryable()
    {
        return _genericRepository.GetQueryable();
    }

    public async Task Delete(int id)
    {
        await _genericRepository.Delete(id);
    }

    public async Task<List<TEntity>> GetAll()
    {
        return await _genericRepository.GetAll();
    }

    public async Task<TEntity> GetById(int id)
    {
        return await _genericRepository.GetById(id);
    }

    public async Task<TEntity> Insert(TEntity entity)
    {
        return await _genericRepository.Insert(entity);
    }

    public async Task<TEntity> Update(TEntity entity)
    {
        return await _genericRepository.Update(entity);
    }

    public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return _genericRepository.SingleOrDefaultAsync(predicate);
    }    
}
