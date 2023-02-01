using SmartAgency._1_Core.Data.Entities;

namespace SmartAgency._1_Core.Data.Repositories;

public interface IWriteRepository<in TEntity> where TEntity : class, IEntity
{
    void Add(TEntity entity);
    void Remove(Guid id);
    void Save();

}