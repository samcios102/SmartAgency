using Microsoft.EntityFrameworkCore;
using SmartAgency.Data.Entities;

namespace SmartAgency.Data.Repositories;

public class SqlRepository<T> : IRepository<T> where T : class, IEntity
{
    private readonly  DbContext _dbContext;
    private readonly DbSet<T> _dbSet;

    public SqlRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<T>();
    }

    public T GetById(Guid id)
    {
        return _dbSet.Find(id);
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity); 
    }

    public void Remove(Guid id)
    {
        foreach (var item in _dbSet)
        {
            if (item.Id == id)
            {
                _dbSet.Remove(item);
            }
        }
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }
}