using SmartAgency._1_DataAccess.Data.Entities;

namespace SmartAgency._1_DataAccess.Data.Repositories;

public interface IRepository<TEntity> : IReadRepository<TEntity>, IWriteRepository<TEntity>
    where TEntity : class, IEntity
{
    
}