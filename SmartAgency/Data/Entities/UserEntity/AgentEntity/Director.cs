using SmartAgency.Data.Entities.UserEntity.ClientEntity;
using SmartAgency.Data.Entities.ValueObjects;

namespace SmartAgency.Data.Entities.UserEntity.AgentEntity;

public record Director(Guid Id, Name FirstName, Name LastName, Email Email, DateOnly DateAdded, List<Client> ClientList) 
    : Manager(Id, FirstName, LastName, Email, DateAdded, ClientList);