using System.Collections;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmartAgency;
using SmartAgency._1_DataAccess.Data;
using SmartAgency._1_DataAccess.Data.Entities.Enums;
using SmartAgency._1_DataAccess.Data.Entities.PropertyEntity;
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
//services.AddSingleton<IRepository<Client>, ListRepository<SellContracts>>();

services.AddSingleton<DbContext, SmartAgencyAppDbContext>();

/*services.AddDbContext<SmartAgencyAppDbContext>(options => options
    .UseSqlServer("Data Source=SAMUEL-MAIN\\SQLEXPRESS02;Initial Catalog=SmartAgencyStorage;Integrated Security=True;TrustServerCertificate=True"));*/


//services.AddDbContext<SmartAgencyAppDbContext>(); // nie wiem czy potrzebne


var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>();
app.Run();











/*

*/

var agent1 = new Agent(Guid.NewGuid(), "samuel", "piwnicki", "sam@samn.pl", DateOnly.FromDateTime(DateTime.Now) , new List<Client>());



//var contract1 = new SellContract(Guid.NewGuid(), DateOnly.FromDateTime(DateTime.Now), 2, property1);



/*
var clientRepository = new ListRepository<Client>();

clientRepository.Add(client1);
clientRepository.Add(client2);
clientRepository.Remove(client2.Id);


clientRepository.Save();*/

var sqlRepository = new SqlRepository<Client>(new SmartAgencyAppDbContext());
//sqlRepository.Add(client1);
//sqlRepository.Add(client2);
//sqlRepository.Save();

Console.WriteLine(sqlRepository.ToString());


var localisation1 = new Localisation(LocalisationDistrict.Ursynow, "Slawska", 70, 3);

var stringLocalisation1 = localisation1.ToString();
var arrayLocalisation1 = stringLocalisation1.Split(',');




/*var sqlPropertyRepository = new SqlRepository<Property>(new SmartAgencyAppDbContext());
sqlPropertyRepository.Add(property1);
sqlPropertyRepository.Add(property1 with{ Id = Guid.NewGuid()});
sqlPropertyRepository.Save();

foreach (var property in sqlPropertyRepository.GetAll())
{
    Console.WriteLine(property);
}*/






