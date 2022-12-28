using System.Collections;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.DependencyInjection;
using SmartAgency;
using SmartAgency.Data;
using SmartAgency.Data.Entities.ContractEntity;
using SmartAgency.Data.Entities.Enums;
using SmartAgency.Data.Entities.PropertyEntity;
using SmartAgency.Data.Entities.UserEntity;
using SmartAgency.Data.Entities.UserEntity.AgentEntity;
using SmartAgency.Data.Entities.UserEntity.ClientEntity;
using SmartAgency.Data.Entities.ValueObjects;
using SmartAgency.Data.Repositories;



var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Property>, ListRepository<Property>>();
services.AddSingleton<IRepository<Client>, ListRepository<Client>>(); 
//services.AddSingleton<IRepository<Client>, ListRepository<Client>>();

//services.AddDbContext<SmartAgencyAppDbContext>(); // nie wiem czy potrzebne


var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>();
app.Run();











/*
var client1 = new Client(Guid.NewGuid(), "Samczi", "Piwnica", "sam@saczi.pl", DateOnly.Parse("1996-3-14"));
var client2 = new Client(Guid.NewGuid(), "Naczi", "Wingorono", "nacz@naczi.pl", DateOnly.Parse("1997-4-15"));
*/

var agent1 = new Agent(Guid.NewGuid(), "samuel", "piwnicki", "sam@samn.pl", DateOnly.FromDateTime(DateTime.Now) , new List<Client>());

var property1 = new Property(123, new Localisation(LocalisationDistrict.Wilanow, "Wilanowska", null, null), 2, 50,
    TechnicalCondition.ToMoveIn);

var contract1 = new SellContract(Guid.NewGuid(), DateOnly.FromDateTime(DateTime.Now), 2, property1);



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


var localisation1 = new Localisation(LocalisationDistrict.Ursynow, "Pulawska", 270, 73);

var stringLocalisation1 = localisation1.ToString();
var arrayLocalisation1 = stringLocalisation1.Split(',');




var sqlPropertyRepository = new SqlRepository<Property>(new SmartAgencyAppDbContext());
sqlPropertyRepository.Add(property1);
sqlPropertyRepository.Add(property1 with{ Id = Guid.NewGuid()});
sqlPropertyRepository.Save();

foreach (var property in sqlPropertyRepository.GetAll())
{
    Console.WriteLine(property);
}



