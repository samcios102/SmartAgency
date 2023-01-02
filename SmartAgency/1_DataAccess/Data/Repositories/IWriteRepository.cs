using SmartAgency._1_DataAccess.Data.Entities;

namespace SmartAgency._1_DataAccess.Data.Repositories;

public interface IWriteRepository<in T> where T : class, IEntity
{
    void Add(T entity);
    void Remove(Guid id);
    void Save();

}