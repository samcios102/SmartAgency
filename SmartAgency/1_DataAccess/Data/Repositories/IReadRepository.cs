using SmartAgency._1_DataAccess.Data.Entities;

namespace SmartAgency._1_DataAccess.Data.Repositories;

public interface IReadRepository<out TEntity> where TEntity : class,IEntity
{
    TEntity GetById(Guid id);
    IEnumerable<TEntity> GetAll();


}