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

        public List<Client> SortClientByDateAdded(bool ascending)
        {
            var clients = _clientRepository.GetAll();

            if (ascending)
            {
                return clients.OrderBy(x => x.DateAdded)
                    .ThenBy(x => x.LastName.Value)
                    .ToList();
            }
            else
            {
                return clients.OrderByDescending(x => x.DateAdded)
                    .ThenBy(x => x.LastName.Value)
                    .ToList();
            }
                
            
        }

        public List<Client> FilterClientsAddedAfterDate(DateOnly date)
        {

            var clients = _clientRepository.GetAll()
                .Where(x => x.DateAdded > date);


            return clients.ToList();
        }

        public List<Client> ShowBasicColumn()
        {
            var clients = _clientRepository.GetAll()
                .Select(x => new Client
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    DateAdded = x.DateAdded
                });
            return clients.ToList();
        }

        public List<Client> ShowPage(int pageNr)
        {
            var clients = _clientRepository.GetAll()
                .OrderByDescending(x => x.DateAdded)
                .Skip((pageNr - 1) * 20)
                .Take(20);

            if (!clients.Any())
            {
                throw new ArgumentException("Page not found");
            }


            return clients.ToList();
        }
    }
}
