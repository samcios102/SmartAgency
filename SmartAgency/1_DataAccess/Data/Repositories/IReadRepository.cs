using SmartAgency._1_DataAccess.Data.Entities;

namespace SmartAgency._1_DataAccess.Data.Repositories;

public interface IReadRepository<out T> where T : class,IEntity
{
    T GetById(Guid id);
    IEnumerable<T> GetAll();


}