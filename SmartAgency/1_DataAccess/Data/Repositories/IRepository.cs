using SmartAgency.Data.Entities;

namespace SmartAgency.Data.Repositories;

public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T>
    where T : class, IEntity
{
    
}