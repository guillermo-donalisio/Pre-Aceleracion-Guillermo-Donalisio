using System.Linq.Expressions;
using Api_Disney.Data;
using Api_Disney.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Disney.Repositories.Implements;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private DisneyContext _disneyContext;

    public GenericRepository(DisneyContext disneyContext)
    {
        this._disneyContext = disneyContext;   
    }    
    
    public async Task Delete(int id)
    {
        var entity = await GetById(id);

        if(entity == null)
			throw new Exception("The entity is null");

        _disneyContext.Set<TEntity>().Remove(entity);
		await _disneyContext.SaveChangesAsync();
    }

    public async Task<List<TEntity>> GetAll()
    {
        return await _disneyContext.Set<TEntity>().ToListAsync();	
    }

    public async Task<TEntity> GetById(int id)
    {
        return await _disneyContext.Set<TEntity>().FindAsync(id);
    }

    public async Task<TEntity> Insert(TEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        await _disneyContext.Set<TEntity>().AddAsync(entity);
        await _disneyContext.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> Update(TEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        _disneyContext.Set<TEntity>().Update(entity);
        await _disneyContext.SaveChangesAsync();
        return entity;
    }

    public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return _disneyContext.Set<TEntity>().SingleOrDefaultAsync(predicate);
    }

    public IQueryable<TEntity> GetQueryable()
    {
        return _disneyContext.Set<TEntity>();
    }   
}
