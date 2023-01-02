using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgency.Data.Entities.ContractEntity
{
    public interface IContract : IEntity
    { 
        DateOnly ExpiryDate { get; init; }
        int Commission { get; init; }


    }
}
