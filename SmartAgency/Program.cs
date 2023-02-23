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
using SmartAgency._2_ApplicationServices.Components.CsvReader;
using SmartAgency._2_ApplicationServices.Components.DataProviders;
using SmartAgency._3_UI;
using SmartAgency._3_UI.UserOperations;
using Spectre.Console;





var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Property>, ListRepository<Property>>();
services.AddSingleton<ICsvReader<Client>, CsvReader<Client>>();
services.AddSingleton<IUserProvider<Client>, UserProvider<Client>>();
services.AddSingleton<IUserOperations<Client>, UserOperationsBase<Client>>();


// service collector TO CREATE
// events TO CREATE
// migrations SQL TO CREATE
// SQL dataAdded mapp / migration idk
// db choose type secured to choose only from 3 types


//services.AddSingleton<IRepository<Client>, ListRepository<SellContracts>>();

AnsiConsole.MarkupLine($"Choose database: (1) MS SQL, (2) InMemory, (3) Local JSON");
var dbType = Console.ReadLine();

if (dbType == "1")
{
    var connectionString =
        "Data Source=SAMUEL-MAIN\\SQLEXPRESS02;Initial Catalog=SmartAgencyStorage;Integrated Security=True;TrustServerCertificate=True";
    services.AddSingleton<IRepository<Client>, SqlRepository<Client>>();
    services.AddSingleton<DbContext, SmartAgencyAppDbContext>();
    services.AddDbContext<SmartAgencyAppDbContext>(options => options
        .UseSqlServer(connectionString, x => x.UseDateOnlyTimeOnly())
    );
}

if (dbType == "2")
{
    services.AddSingleton<IRepository<Client>, SqlRepository<Client>>();
    services.AddSingleton<DbContext, SmartAgencyAppDbContextInMemory>();
}

if (dbType == "3")
{
    services.AddSingleton<IRepository<Client>, XmlRepository<Client>>();
    //services.AddSingleton<DbContext, SmartAgencyAppDbContextInMemory>();
}



//services.AddDbContext<SmartAgencyAppDbContext>(); // nie wiem czy potrzebne


var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>()!;
app.Run();







