using SmartAgency.Data.Entities.UserEntity.ClientEntity;
using SmartAgency.Data.Entities.ValueObjects;

namespace SmartAgency.Data.Entities.UserEntity.AgentEntity;

public record Agent(Guid Id, Name FirstName, Name LastName, Email Email, DateOnly DateAdded, List<ClientEntity.Client>? ClientList)
    : User/*(Id, FirstName, LastName, Email, DateAdded)*/;