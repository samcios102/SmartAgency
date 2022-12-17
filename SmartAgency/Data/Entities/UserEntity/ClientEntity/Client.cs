using SmartAgency.Data.Entities.ContractEntity;
using SmartAgency.Data.Entities.ValueObjects;

namespace SmartAgency.Data.Entities.UserEntity.ClientEntity;

public record Client(Guid Id, Name FirstName, Name LastName, Email Email, DateOnly DateAdded)
    : User(Id, FirstName, LastName, Email, DateAdded);
