using SmartAgency.Data.Entities.ContractEntity;
using SmartAgency.Data.Entities.ValueObjects;

namespace SmartAgency.Data.Entities.UserEntity.ClientEntity;

public record VipContractClient(Guid Id, Name FirstName, Name LastName, Email Email, DateOnly DateAdded, List<IContract>? Contracts)
    : ContractClient(Id, FirstName, LastName, Email, DateAdded, Contracts);

