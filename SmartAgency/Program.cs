using System.Reflection.Metadata;
using SmartAgency.Data.Entities.ContractEntity;
using SmartAgency.Data.Entities.Enums;
using SmartAgency.Data.Entities.PropertyEntity;
using SmartAgency.Data.Entities.UserEntity.AgentEntity;
using SmartAgency.Data.Entities.UserEntity.ClientEntity;
using SmartAgency.Data.Entities.ValueObjects;

var client1 = new Client(Guid.NewGuid(), "samczi", "piw", "sam@saczi.pl", DateOnly.Parse("1996-3-14"));

var agent1 = new Agent(Guid.NewGuid(), "samuel", "piwnicki", "sam@samn.pl", DateOnly.FromDateTime(DateTime.Now) , new List<Client>());

var property1 = new Property(123, new Localisation(LocalisationDistrict.Wilanow, "Wilanowska", null, null), 2, 50,
    TechnicalCondition.ToMoveIn);

var contract1 = new SellContract(Guid.NewGuid(), DateOnly.FromDateTime(DateTime.Now), 2, property1);


Console.WriteLine(client1);
Console.WriteLine(agent1);
Console.WriteLine(property1);
Console.WriteLine(contract1);
