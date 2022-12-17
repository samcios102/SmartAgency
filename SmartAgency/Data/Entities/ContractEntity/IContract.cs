using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgency.Data.Entities.ContractEntity
{
    public interface IContract : IEntity
    { 
        public DateOnly ExpiryDate { get; init; }
        public int Commission { get; init; }


    }
}
