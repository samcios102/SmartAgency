namespace SmartAgency._1_Core.Data.Entities.ContractEntity
{
    public interface IContract : IEntity
    { 
        DateOnly ExpiryDate { get; init; }
        int Commission { get; init; }


    }
}
