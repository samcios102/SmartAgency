using System.Collections;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmartAgency;
using SmartAgency._1_DataAccess.Data;
using SmartAgency._1_DataAccess.Data.Entities.Enums;
using SmartAgency._1_DataAccess.Data.Entities.PropertyEntity;
using SmartAgency._1_DataAccess.Data.Entities.UserEntity;
using SmartAgency._1_DataAccess.Data.Entities.UserEntity.AgentEntity;
using SmartAgency._1_DataAccess.Data.Entities.UserEntity.ClientEntity;
using SmartAgency._1_DataAccess.Data.Entities.ValueObjects;
using SmartAgency._1_DataAccess.Data.Repositories;
using SmartAgency._2_ApplicationServices.Components.CsvReader;
using SmartAgency._2_ApplicationServices.Components.DataProviders;
using SmartAgency._3_UI;


var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Property>, ListRepository<Property>>();
services.AddSingleton<IRepository<Client>, SqlRepository<Client>>();
services.AddSingleton<ICsvReader, CsvReader>();
services.AddSingleton<IUserProvider<Client>, UserProvider<Client>>();
services.AddSingleton<IUserOperations<Client>, UserOperationsBase<Client>>();

//services.AddSingleton<IRepository<Client>, ListRepository<SellContracts>>();

services.AddSingleton<DbContext, SmartAgencyAppDbContext>();

services.AddDbContext<SmartAgencyAppDbContext>(options => options
    .UseSqlServer("Data Source=SAMUEL-MAIN\\SQLEXPRESS02;Initial Catalog=SmartAgencyStorage;Integrated Security=True;TrustServerCertificate=True")
);


//services.AddDbContext<SmartAgencyAppDbContext>(); // nie wiem czy potrzebne


var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>()!;
app.Run();







