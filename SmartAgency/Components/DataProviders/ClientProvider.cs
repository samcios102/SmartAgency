using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartAgency.Data.Entities.UserEntity.ClientEntity;
using SmartAgency.Data.Repositories;

namespace SmartAgency.Components.DataProviders
{
    public class ClientProvider : IClientProvider
    {
        private readonly IRepository<Client> _clientRepository;

        public ClientProvider(IRepository<Client> clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public List<Client> ShowClients()
        {
            return _clientRepository.GetAll().ToList();
        }

        public List<Client> SearchClients(string searchValue)
        {
            var guidTryParsed = Guid.TryParse(searchValue, out var newGuid);
            var dateOnlyTryParsed = DateOnly.TryParse(searchValue, out var newDateOnly);

            var clients = _clientRepository.GetAll()
                .Where(x => 
                    x.Id.Equals(newGuid) ||
                    x.FirstName.Value.Equals(searchValue, StringComparison.InvariantCultureIgnoreCase) || 
                    x.LastName.Value.Equals(searchValue, StringComparison.InvariantCultureIgnoreCase) ||
                    x.Email.Value.Equals(searchValue, StringComparison.InvariantCultureIgnoreCase) ||
                    x.DateAdded.Equals(newDateOnly)
                    );


            return clients.ToList();
        }

        public List<Client> SortClients(int chooseOption)
        {
            throw new NotImplementedException();
        }

        public List<Client> FilterClients()
        {
            throw new NotImplementedException();
        }

        public List<Client> GetSpecificColumns(int chooseOption)
        {
            throw new NotImplementedException();
        }
    }
}
