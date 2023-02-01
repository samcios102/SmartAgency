using SmartAgency._1_Core.Data.Entities.ValueObjects;

namespace SmartAgency._1_Core.Data.Entities.UserEntity.AgentEntity;

public record Director(Guid Id, Name FirstName, Name LastName, Email Email, DateOnly DateAdded, List<ClientEntity.Client> ClientList) 
    : Manager(Id, FirstName, LastName, Email, DateAdded, ClientList);