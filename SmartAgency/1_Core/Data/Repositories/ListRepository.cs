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

    /*public void Update(Guid id, T entity)
    {

        //var index = _itemList.FindIndex(x => x.Id == id);


        T newObject = (T)Activator.CreateInstance(
            entity.GetType(), new object(
                foreach (var prop in typeof(T).GetProperties())
                {
                    prop.GetValue(entity);
                }));

                foreach (var entityProperty in entity.GetType().GetProperties())
        {
            Console.WriteLine(entityProperty);
        }

        //Console.WriteLine($"Updated {id} with {updatedObj.ToString()}\n");
    }*/
    
    
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