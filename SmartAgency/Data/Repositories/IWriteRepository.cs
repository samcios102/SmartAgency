using SmartAgency.Data.Entities;

namespace SmartAgency.Data.Repositories;

public interface IWriteRepository<in T> where T : class, IEntity
{
    void Add(T entity);
    void Remove(Guid id);
    void Save();

}