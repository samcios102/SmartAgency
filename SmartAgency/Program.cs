using System.Collections;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmartAgency;
using SmartAgency._1_Core.Data;
using SmartAgency._1_Core.Data.Entities.PropertyEntity;
using SmartAgency._1_Core.Data.Entities.UserEntity.ClientEntity;
using SmartAgency._1_Core.Data.Repositories;
using SmartAgency._2_ApplicationServices;
using SmartAgency._2_ApplicationServices.Components.CsvReader;
using SmartAgency._2_ApplicationServices.Components.DataProviders;
using SmartAgency._2_ApplicationServices.Services.UserInteractions;
using SmartAgency._3_UI;
using SmartAgency._3_UI.UserOperations;
using Spectre.Console;


var services = new ServiceCollection();
services.AddSingleton<IRepository<Property>, ListRepository<Property>>();
services.AddSingleton<ICsvReader<Client>, CsvReader<Client>>();
services.AddSingleton<IUserProvider<Client>, UserProvider<Client>>();
services.AddSingleton<IUserOperations<Client>, UserOperationsBase<Client>>();
services.AddSingleton<IUserInteractions<Client>, UserInteractions<Client>>();
services.AddSingleton<IEventHandlerService, EventHandlerService>();


AnsiConsole.MarkupLine($"Choose database: (1) MS SQL, (2) InMemory, (3) Local XML");
var dbType = Console.ReadLine();

if (dbType == "1")
{
    var connectionString =
        "Data Source=SAMUEL-MAIN\\SQLEXPRESS02;Initial Catalog=SmartAgencyStorage;Integrated Security=True;TrustServerCertificate=True";
    services.AddSingleton<IApp, App>();
    services.AddSingleton<IRepository<Client>, SqlRepository<Client>>();
    services.AddSingleton<DbContext, SmartAgencyAppDbContext>();
    services.AddDbContext<SmartAgencyAppDbContext>(options => options
        .UseSqlServer(connectionString, x => x.UseDateOnlyTimeOnly()) // niepotrzebne use dateonly time only, bo jest to w nuget library
    );

}

if (dbType == "2" || dbType == "3")
{
    services.AddSingleton<IApp, AppInMemory>();
    services.AddSingleton<DbContext, SmartAgencyAppDbContextInMemory>();
    services.AddDbContext<SmartAgencyAppDbContextInMemory>();
}

if (dbType == "2")
{
    services.AddSingleton<IRepository<Client>, SqlRepository<Client>>(); 
}

if (dbType == "3")
{
    services.AddSingleton<IRepository<Client>, XmlRepository<Client>>();   
}


var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>()!;
app.Run();



                

