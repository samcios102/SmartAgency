using SmartAgency._1_DataAccess.Data.Entities.ContractEntity;
using SmartAgency._1_DataAccess.Data.Entities.ValueObjects;

namespace SmartAgency._1_DataAccess.Data.Entities.UserEntity.ClientEntity;

public record ContractClient(Guid Id, Name FirstName, Name LastName, Email Email, DateOnly DateAdded, List<IContract>? Contracts) 
    : Client/*(Id, FirstName, LastName, Email, DateAdded)*/;
