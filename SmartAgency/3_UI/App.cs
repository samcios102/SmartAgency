using Microsoft.EntityFrameworkCore.Migrations;
using SmartAgency._1_Core.Data.Entities.Enums;
using SmartAgency._1_Core.Data.Entities.PropertyEntity;
using SmartAgency._1_Core.Data.Entities.UserEntity.ClientEntity;
using SmartAgency._1_Core.Data.Entities.ValueObjects;
using SmartAgency._2_ApplicationServices.Components.CsvReader;
using SmartAgency._2_ApplicationServices.Components.DataProviders;
using SmartAgency._3_UI.UserOperations;
using Spectre.Console;


namespace SmartAgency._3_UI;

public class App : IApp
{

    //private readonly IRepository<Property> _propertyRepository;
    //private readonly IRepository<Client> _clientRepository;
    //private readonly IUserProvider<Client> _clientProvider;

    private readonly ICsvReader<Client> _csvClientReader;
    private readonly IUserOperations<Client> _clientOperations;

    //private readonly SmartAgencyAppDbContext _dbContext; // MS SQL - needed?

    public App(
        //IRepository<Property> propertyRepository,
        //IRepository<Client> clientRepository,
        //IUserProvider<Client> clientProvider,
        IUserOperations<Client> clientOperations
        //SmartAgencyAppDbContext dbContext // MS SQL - needed?
        )
    {
        //_propertyRepository = propertyRepository;
        //_clientRepository = clientRepository;
        //_clientProvider = clientProvider;
        _clientOperations = clientOperations;
        /*_dbContext = dbContext; // MS SQL - needed?
        dbContext.Database.EnsureCreated();*/ // MS SQL - needed?
    }

    public void Run()
    {
      



    //user interaction, handler?
    // user pick interaction

    // operation is sequance of interactions

    //_clientOperations.ShowUsers();

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
                    _clientOperations.LoadUsersFromCsv();
                    break;
                case "8":
                    break;

            }
            
        } while (selection is not "8");
    }
}