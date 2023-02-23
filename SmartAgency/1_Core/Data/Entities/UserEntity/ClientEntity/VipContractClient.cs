using SmartAgency._1_Core.Data.Entities.ContractEntity;
using SmartAgency._1_Core.Data.Entities.ValueObjects;

namespace SmartAgency._1_Core.Data.Entities.UserEntity.ClientEntity;

public record VipContractClient(Guid Id, Name FirstName, Name LastName, Email Email, DateOnly DateAdded, List<IContract>? Contracts)
    : ContractClient(Id, FirstName, LastName, Email, DateAdded, Contracts);

