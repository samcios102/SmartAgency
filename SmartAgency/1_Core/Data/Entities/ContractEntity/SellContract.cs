using SmartAgency._1_Core.Data.Entities.PropertyEntity;

namespace SmartAgency._1_Core.Data.Entities.ContractEntity
{
    public record SellContract(Guid Id, DateOnly ExpiryDate, int Commission, Property Property) : IContract
    {
        public void ChangeExpiryDate(DateOnly expiryDate)
        {
            //ExpiryDate = expiryDate;
        }
        
    }

}
