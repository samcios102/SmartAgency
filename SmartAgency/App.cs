using SmartAgency.Components.CsvReader;
using SmartAgency.Data.Entities.Enums;
using SmartAgency.Data.Entities.PropertyEntity;
using SmartAgency.Data.Entities.UserEntity.ClientEntity;
using SmartAgency.Data.Entities.ValueObjects;
using SmartAgency.Data.Repositories;
using System.Formats.Asn1;

namespace SmartAgency;

public class App : IApp
{
   
    private readonly IRepository<Property> _propertyRepository;
    private readonly IRepository<Client> _clientRepository;
    private readonly ICsvReader _csvReader;

    public App(
        IRepository<Property> propertyRepository,
        IRepository<Client> clientRepository,
        ICsvReader csvReader
        )
    {
        _propertyRepository = propertyRepository;
        _clientRepository = clientRepository;
        _csvReader = csvReader;
    }

        public void Run()
    {
        Console.WriteLine("Im in Run App");

        var property1 = new Property(12, new Localisation(LocalisationDistrict.Mokotow, "d", 2, 2), 2, 44, TechnicalCondition.ToGeneralRenovation);
        var property2 = new Property(123, new Localisation(LocalisationDistrict.Wilanow, "Wilanowska", null, null), 2, 50,
            TechnicalCondition.ToMoveIn);

        _propertyRepository.Add(property1);
        _propertyRepository.Add(property2);
        _propertyRepository.Save();

        var client1 = new Client(Guid.NewGuid(), "Samczi", "Piwnica", "sam@saczi.pl", DateOnly.Parse("1996-3-14"));
        var client2 = new Client(Guid.NewGuid(), "Naczi", "Wingorono", "nacz@naczi.pl", DateOnly.Parse("1997-4-15"));

        _clientRepository.Add(client1);
        _clientRepository.Add(client2);
        _clientRepository.Save();

        foreach (var client in _clientRepository.GetAll())               
        {
            Console.WriteLine(client);
        }

        var csvClients = _csvReader.ProcessClients("Resources\\Files\\ClientExample.csv");












    }
}