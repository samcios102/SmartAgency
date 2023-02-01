using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SmartAgency._1_Core.Data.Entities;

namespace SmartAgency._1_Core.Data.Repositories
{
    public class XmlRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private static readonly string _type = typeof(TEntity).Name;
        private readonly XDocument _xDocument = LoadOrCreateNewXDocument(); // need to check if null


 
        public void Add(TEntity entity)
        {
            var element = new XElement($"{_type}");
            var properties = typeof(TEntity).GetProperties();

            foreach (var property in properties)
            {
                element.SetAttributeValue(property.Name, property.GetValue(entity));

            }

            _xDocument.Root.AddFirst(element);

            /*node.Add(new XElement($"{_type}"),
                from property in properties
                select (new XAttribute(property.Name, property.GetValue(entity)))
            );*/


        }


        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();

        }

        public TEntity GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _xDocument.Save($"{_type}s.xml");
        }


        private static XDocument LoadOrCreateNewXDocument()
        {
            var document = new XDocument();

            try
            {
                document = XDocument.Load($"{_type}s.xml");
                if (document != null)
                {
                    return document;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"There is no document with name {_type}s \nNew document is created with name {_type}s \n Message from console below: \n{e.Message}");
                document = new XDocument();
                document.Add(new XElement($"{_type}s"));
                document.Save($"{_type}s.xml");
            }

            return document;
        }

    }
}
