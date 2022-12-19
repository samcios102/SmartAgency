using SmartAgency.Data.Entities;

namespace SmartAgency.Data.Repositories;

public interface IReadRepository<out T> where T : class,IEntity
{
    T Get(Guid id);
    IEnumerable<T> GetAll();


}