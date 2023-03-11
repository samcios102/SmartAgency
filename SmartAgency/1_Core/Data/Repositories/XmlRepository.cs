using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Xml;
 using System.Xml.Linq;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SmartAgency._1_Core.Data.Entities;
using SmartAgency._1_Core.Data.Entities.ValueObjects;

namespace SmartAgency._1_Core.Data.Repositories
{
    public class XmlRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        
        private readonly XDocument _xDocument = LoadOrCreateNewXDocument(); // need to check if null
        private static readonly string _type = typeof(TEntity).Name;

        public event EventHandler<TEntity>? EntityAdded;
        public event EventHandler<TEntity>? EntityDeleted;
        public void Add(TEntity entity)
        {
            var element = new XElement($"{_type}");
            var properties = typeof(TEntity).GetProperties();

            foreach (var property in properties)
            {
                element.SetAttributeValue(property.Name, property.GetValue(entity));

            }

            _xDocument.Root.AddFirst(element);
            EntityAdded?.Invoke(this, entity);

        }


        public IEnumerable<TEntity> GetAll()
        {
            
            return _xDocument.Root.Descendants().Select(element => FromXml(element));
        }

        public TEntity GetById(Guid id)
        {
            var entities = this.GetAll();

            return entities.Where(x => x.Id == id).FirstOrDefault();
                  

        }

        public void Remove(Guid id)
        {
            var entity = GetById(id);
            
            _xDocument.Root.Descendants().Where(node => (string) node.Attribute("Id") == id.ToString()).Remove();

            EntityDeleted?.Invoke(this, entity);
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


        private static TEntity FromXml(XElement xElement)
        {
            var entity = new TEntity();
            
            foreach (var xAttribute in xElement.Attributes())
            {
                foreach (var propertyInfo in typeof(TEntity).GetProperties())
                {
                    if (xAttribute.Name == propertyInfo.Name)
                    {
                        var xValue = xAttribute.Value;
                        var type = propertyInfo.PropertyType;

                        if (propertyInfo.PropertyType == typeof(DateOnly))
                        {
                            string[] components = xValue.Split('.');
                            xValue = components[1] + "." + components[0] + "." + components[2];
                                                                      
                        }

                        var converter = TypeDescriptor.GetConverter(type).ConvertFromInvariantString(xValue) ;
                        
                        propertyInfo.SetValue(entity, converter);

                    }
                }
            }

            return entity;
        }
    }
}
