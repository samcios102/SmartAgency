using Microsoft.EntityFrameworkCore.Migrations;
using SmartAgency._1_Core.Data;
using SmartAgency._1_Core.Data.Entities.Enums;
using SmartAgency._1_Core.Data.Entities.PropertyEntity;
using SmartAgency._1_Core.Data.Entities.UserEntity.ClientEntity;
using SmartAgency._1_Core.Data.Entities.ValueObjects;
using SmartAgency._2_ApplicationServices;
using SmartAgency._2_ApplicationServices.Components.CsvReader;
using SmartAgency._2_ApplicationServices.Components.DataProviders;
using SmartAgency._2_ApplicationServices.Services.UserInteractions;
using SmartAgency._3_UI.UserOperations;
using Spectre.Console;


namespace SmartAgency._3_UI;

public class App : IApp
{
    private readonly IUserOperations<Client> _clientOperations;
    private readonly IUserInteractions<Client> _clientInteractions;
    private readonly IEventHandlerService _eventHandlerService;
    private readonly SmartAgencyAppDbContext _dbContext;

    public App(
        IUserOperations<Client> clientOperations,
        IUserInteractions<Client> clientInteractions,
        IEventHandlerService eventHandler,
        SmartAgencyAppDbContext dbContext
        )
    {
        _clientOperations = clientOperations;
        _clientInteractions = clientInteractions;
        _eventHandlerService = eventHandler;
        _dbContext = dbContext;
        dbContext.Database.EnsureCreated();
    }

    public void Run()
    {
        _eventHandlerService.SubscribeToEvents();
        _clientInteractions.ChooseActions();
          
    }
}