using SmartAgency._1_Core.Data.Entities.UserEntity.ClientEntity;
using SmartAgency._1_Core.Data.Repositories;
using SmartAgency._2_ApplicationServices.Components.CsvReader;
using SmartAgency._2_ApplicationServices.Components.DataProviders;

namespace SmartAgency._3_UI.UserOperations
{
    public class ClientOperations : UserOperationsBase<Client>
    {
        public ClientOperations
            (
            IUserProvider<Client> userProvider, 
            IRepository<Client> userRepository, 
            ICsvReader<Client> csvReader) 
                : base(userProvider, userRepository, csvReader)
        {
        }
    }
}
