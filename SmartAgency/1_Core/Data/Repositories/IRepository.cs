using SmartAgency._1_Core.Data.Entities;

namespace SmartAgency._1_Core.Data.Repositories;

public interface IRepository<TEntity> : IReadRepository<TEntity>, IWriteRepository<TEntity>
    where TEntity : class, IEntity
{
    public event EventHandler<TEntity>? EntityAdded;
    public event EventHandler<TEntity>? EntityDeleted;
}