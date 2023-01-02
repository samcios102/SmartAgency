using SmartAgency._1_DataAccess.Data.Entities.PropertyEntity;

namespace SmartAgency._1_DataAccess.Data.Entities.ContractEntity
{
    public record SellContract(Guid Id, DateOnly ExpiryDate, int Commission, Property Property) : IContract
    {
        public void ChangeExpiryDate(DateOnly expiryDate)
        {
            //ExpiryDate = expiryDate;
        }
        
    }

}
