using Microsoft.EntityFrameworkCore;
using SmartAgency._1_Core.Data.Entities;

namespace SmartAgency._1_Core.Data.Repositories;

public class SqlRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
{
    private readonly DbContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;

    public SqlRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<TEntity>();
    }

    public TEntity GetById(Guid id)
    {
        return _dbSet.Find(id);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _dbSet.ToList();
    }

    public void Add(TEntity entity)
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