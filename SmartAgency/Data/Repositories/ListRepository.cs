using System.Collections;
using System.Reflection;
using SmartAgency.Data.Entities;
using SmartAgency.Data.Entities.UserEntity.ClientEntity;

namespace SmartAgency.Data.Repositories;

public class ListRepository<T> : IRepository<T> where T : class, IEntity
{
    protected readonly List<T> _itemList = new List<T>();

    public T Get(Guid id)
    {
        return _itemList.SingleOrDefault(x => x.Id == id);
    }

    public IEnumerable<T> GetAll()
    {
        return _itemList.ToList();
    }

    public void Add(T entity)
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
        _itemList.Remove(_itemList.FirstOrDefault(x => x.Id == id));
    }

    public void Save()
    {
        foreach (var entity in _itemList)
        {
            Console.WriteLine(entity + $"\n");
        }
    }

}