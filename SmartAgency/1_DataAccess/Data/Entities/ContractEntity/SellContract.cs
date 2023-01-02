using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartAgency.Data.Entities.PropertyEntity;

namespace SmartAgency.Data.Entities.ContractEntity
{
    public record SellContract(Guid Id, DateOnly ExpiryDate, int Commission, Property Property) : IContract
    {
        public void ChangeExpiryDate(DateOnly expiryDate)
        {
            //ExpiryDate = expiryDate;
        }
        
    }

}
