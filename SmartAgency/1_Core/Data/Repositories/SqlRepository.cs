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

    public event EventHandler<TEntity>? EntityAdded;
    public event EventHandler<TEntity>? EntityDeleted;

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
        EntityAdded?.Invoke(this, entity);
    }

    public void Remove(Guid id)
    {
        foreach (var entity in _dbSet)
        {
            if (entity.Id == id)
            {
                _dbSet.Remove(entity);
                EntityDeleted?.Invoke(this, entity);
            }
        }
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }
}