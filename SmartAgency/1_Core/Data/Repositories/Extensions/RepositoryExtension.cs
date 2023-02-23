using SmartAgency._1_Core.Data.Entities;

namespace SmartAgency._1_Core.Data.Repositories.Extensions;

public static class RepositoryExtension
{
    public static void AddBatch<TEntity>(this IRepository<TEntity> repository, IEnumerable<TEntity> entities)
        where TEntity : class, IEntity
    {
        foreach (var entity in entities)
        {
            repository.Add(entity);
        }

        repository.Save();

    }
}