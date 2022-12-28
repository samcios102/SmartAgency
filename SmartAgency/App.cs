using SmartAgency.Data.Entities.Enums;
using SmartAgency.Data.Entities.PropertyEntity;
using SmartAgency.Data.Entities.UserEntity.ClientEntity;
using SmartAgency.Data.Entities.ValueObjects;
using SmartAgency.Data.Repositories;

namespace SmartAgency;

public class App : IApp
{
   
    private readonly IRepository<Property> _propertyRepository;
    private readonly IRepository<Client> _clientRepository;

    public App(
        IRepository<Property> propertyRepository,
        IRepository<Client> clientRepository
        )
    {
        _propertyRepository = propertyRepository;
        _clientRepository = clientRepository;
    }

        public void Run()
    {
        Console.WriteLine("Im in Run App");

        var property1 = new Property(12, new Localisation(LocalisationDistrict.Mokotow, "d", 2, 2), 2, 44, TechnicalCondition.ToGeneralRenovation);

         _propertyRepository.Add(property1);
        _propertyRepository.Save();



















    }
}