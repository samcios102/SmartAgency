using SmartAgency._1_DataAccess.Data.Entities.ValueObjects;

namespace SmartAgency._1_DataAccess.Data.Entities.UserEntity.AgentEntity;

public record Director(Guid Id, Name FirstName, Name LastName, Email Email, DateOnly DateAdded, List<ClientEntity.Client> ClientList) 
    : Manager(Id, FirstName, LastName, Email, DateAdded, ClientList);