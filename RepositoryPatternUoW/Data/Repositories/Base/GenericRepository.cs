using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using RepositoryPatternUoW.Domain;
using System.Linq.Expressions;

namespace RepositoryPatternUoW.Data.Repositories.Base;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet;

    public GenericRepository(ApplicationContext context)
    {
        _dbSet = context.Set<T>();
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }


    public async Task<int> CountAsync(Expression<Func<T, bool>> expression)
    {
        return await _dbSet.CountAsync(expression);
    }

    public async Task<T> FirstAsync(Expression<Func<T, bool>> expression)
    {
        return await _dbSet.FirstOrDefaultAsync(expression);
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<List<T>> GetDataAsync(
        Expression<Func<T, bool>> expression = null, 
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, 
        int? skip = null, 
        int? take = null)
    {
        var query = _dbSet.AsQueryable();

        if(expression is not null) query = query.Where(expression);

        if(include is not null) query = include(query);

        if (skip is not null && skip.HasValue) query = query.Skip(skip.Value);

        if (take is not null && take.HasValue) query = query.Take(take.Value);

        return await query.ToListAsync();
    }

    
}
