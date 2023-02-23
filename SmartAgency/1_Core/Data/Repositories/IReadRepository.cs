using SmartAgency._1_Core.Data.Entities;

namespace SmartAgency._1_Core.Data.Repositories;

public interface IReadRepository<out TEntity> where TEntity : class,IEntity
{
    TEntity GetById(Guid id);
    IEnumerable<TEntity> GetAll();


}