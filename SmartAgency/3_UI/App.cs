using SmartAgency.Components.CsvReader;
using SmartAgency.Data.Entities.Enums;
using SmartAgency.Data.Entities.PropertyEntity;
using SmartAgency.Data.Entities.UserEntity.ClientEntity;
using SmartAgency.Data.Entities.ValueObjects;
using SmartAgency.Data.Repositories;
using System.Formats.Asn1;
using SmartAgency.Components.CsvReader.Extensions;
using SmartAgency.Components.DataProviders;

namespace SmartAgency;

public class App : IApp
{
   
    private readonly IRepository<Property> _propertyRepository;
    private readonly IRepository<Client> _clientRepository;
    private readonly ICsvReader _csvReader;
    private readonly IUserProvider<Client> _clientProvider;

    public App(
        IRepository<Property> propertyRepository,
        IRepository<Client> clientRepository,
        ICsvReader csvReader,
        IUserProvider<Client> clientProvider
        )
    {
        _propertyRepository = propertyRepository;
        _clientRepository = clientRepository;
        _csvReader = csvReader;
        _clientProvider = clientProvider;
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

        var client1 = new Client(Guid.Parse("a22eff26-2098-4949-88c8-6db38a7125fa"), "Samczi", "Piwnica", "sam@saczi.pl", DateOnly.Parse("1996-3-14"));
        var client2 = new Client(Guid.NewGuid(), "Naczi", "Wingorono", "nacz@naczi.pl", DateOnly.Parse("1997-4-15"));
        var client3 = new Client(Guid.NewGuid(), "Bamto", "Kaskada", "Kaszki@d.pl", DateOnly.Parse("1997-4-15"));

        var csvClients = _csvReader.ProcessClients("Resources\\Files\\ClientExample.csv");

        foreach (var csvClient in csvClients)
        {
            var entityClient = csvClient.ToClient();
            _clientRepository.Add(entityClient);
        }


        _clientRepository.Add(client1);
        _clientRepository.Add(client2);
        _clientRepository.Add(client3);
        _clientRepository.Save();



        



        //_clientProvider.Search("a22eff26-2098-4949-88c8-6db38a7125fa");
        var search = _clientProvider.Search("1997-4-15");

        var sortedClients = _clientProvider.SortByDateAdded(false);

        var filteredClients = _clientProvider.FilterAddedAfterDate(DateOnly.Parse("1996-12-12"));


        var searchedClient = _clientProvider.Search("Myriam");

        var basicColumnClients = _clientProvider.ShowBasicColumn();

        var pagedClients = _clientProvider.ShowPage(4);



        Console.WriteLine();



    }
}