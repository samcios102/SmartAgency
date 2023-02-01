using SmartAgency._1_Core.Data.Entities.ValueObjects;

namespace SmartAgency._1_Core.Data.Entities.UserEntity.AgentEntity;

public record Manager(Guid Id, Name FirstName, Name LastName, Email Email, DateOnly DateAdded, List<ClientEntity.Client> ClientList)
    : Agent(Id, FirstName, LastName, Email, DateAdded, ClientList);