using Microsoft.EntityFrameworkCore.Migrations;
using SmartAgency._1_DataAccess.Data;
using SmartAgency._1_DataAccess.Data.Entities.Enums;
using SmartAgency._1_DataAccess.Data.Entities.PropertyEntity;
using SmartAgency._1_DataAccess.Data.Entities.UserEntity.ClientEntity;
using SmartAgency._1_DataAccess.Data.Entities.ValueObjects;
using SmartAgency._1_DataAccess.Data.Repositories;
using SmartAgency._2_ApplicationServices.Components.CsvReader;
using SmartAgency._2_ApplicationServices.Components.CsvReader.Extensions;
using SmartAgency._2_ApplicationServices.Components.DataProviders;
using Spectre.Console;


namespace SmartAgency._3_UI;

public class App : IApp
{
   
    private readonly IRepository<Property> _propertyRepository;
    private readonly IRepository<Client> _clientRepository;
    private readonly ICsvReader _csvReader;
    private readonly IUserProvider<Client> _clientProvider;
    private readonly IUserOperations<Client> _clientOperations;
    private readonly SmartAgencyAppDbContext _dbContext;

    public App(
        IRepository<Property> propertyRepository,
        IRepository<Client> clientRepository,
        ICsvReader csvReader,
        IUserProvider<Client> clientProvider,
        IUserOperations<Client> clientOperations,
        SmartAgencyAppDbContext dbContext
        )
    {
        _propertyRepository = propertyRepository;
        _clientRepository = clientRepository;
        _csvReader = csvReader;
        _clientProvider = clientProvider;
        _clientOperations = clientOperations;
        _dbContext = dbContext;
        dbContext.Database.EnsureCreated();
    }

        public void Run()
    {
        
        Console.WriteLine("Im in Run App");

        var property1 = new Property(12, new Localisation(LocalisationDistrict.Mokotow, "d", 2, 2), 2, 44, TechnicalCondition.ToGeneralRenovation);
        var property2 = new Property(123, new Localisation(LocalisationDistrict.Wilanow, "Wilanowska", null, null), 2, 50, TechnicalCondition.ToMoveIn);

        /*_propertyRepository.Add(property1);
        _propertyRepository.Add(property2);
        _propertyRepository.Save();*/

        var client1 = new Client(Guid.Parse("a22eff26-2098-4949-88c8-6db38a7125fa"), "Samczi", "Wodniczka", "sam@saczi.pl", DateOnly.Parse("1993-4-14"));
        var client2 = new Client(Guid.NewGuid(), "Naczi", "Wingorono", "nacz@naczi.pl", DateOnly.FromDateTime(DateTime.Now));
        var client3 = new Client(Guid.NewGuid(), "Bamto", "Kaskada", "Kaszki@d.pl", DateOnly.Parse("1997-4-15"));

        var csvClients = _csvReader.ProcessClients("1_DataAccess\\Resources\\Files\\ClientExample.csv");

        /*foreach (var csvClient in csvClients)
        {
            var entityClient = csvClient.ToClient();
            _clientRepository.Add(entityClient);
        }*/


        //_clientRepository.Add(client1);
        //_clientRepository.Add(client2);
        //_clientRepository.Add(client3);
        //_clientRepository.Save();




        //user interaction, handler?
        // user pick interaction

        // operation is sequance of interactions



        var selection = "";
        
        do
        {
            Console.Clear();
            
            _clientOperations.RenderOperations();
            AnsiConsole.MarkupLine($"[orange1] Select operation: [/]");

            selection = Console.ReadLine();

            switch (selection)
            {
                case "1":
                    _clientOperations.ShowUsers();
                    break;
                case "2":
                    _clientOperations.SearchUsers();
                    break;
                case "3":
                    _clientOperations.SortByDateAdded();
                    break;
                case "4":
                    _clientOperations.FilterAddedAfterDate();
                    break;
                case "5":
                    _clientOperations.AddUser();
                    break;
                case "6":
                    _clientOperations.DeleteUser();
                    break;
                case "7":
                    break;

            }
            
        } while (selection is not "7");


       





    }
}