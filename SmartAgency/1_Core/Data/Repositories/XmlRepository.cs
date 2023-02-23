using System.ComponentModel;
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
            
            return _xDocument.Root.Descendants().Select(element => FromXml(element));
        }

        public TEntity GetById(Guid id)
        {
            foreach (var element in _xDocument.Root.Descendants())
            {
                //element.

                /*if (FromXml(element).Id) == id)
                {
                    return FromXml(element);
                }*/
            }
            throw new ArgumentNullException();



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
                        var converter = TypeDescriptor.GetConverter(type).ConvertFromInvariantString(xValue) ;
                        
                        propertyInfo.SetValue(entity, converter);

                    }
                }
            }

            return entity;
        }

        


    }
}
