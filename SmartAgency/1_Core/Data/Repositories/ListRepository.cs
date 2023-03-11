using SmartAgency._1_Core.Data.Entities;

namespace SmartAgency._1_Core.Data.Repositories;

public class ListRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
{
    protected readonly List<TEntity> _itemList = new List<TEntity>();

    public event EventHandler<TEntity>? EntityAdded;
    public event EventHandler<TEntity>? EntityDeleted;

    public TEntity GetById(Guid id)
    {
        return _itemList.SingleOrDefault(x => x.Id == id);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _itemList.ToList();
    }

    public void Add(TEntity entity)
    {
        _itemList.Add(entity);
    }
  
    public void Remove(Guid id)
    {
        var entity = _itemList.FirstOrDefault(x => x.Id == id);
        _itemList.Remove(entity);
        EntityDeleted?.Invoke(this, entity);
    }

    public void Save()
    {
        foreach (var entity in _itemList)
        {
            Console.WriteLine(entity + $"\n");
        }
    }

}