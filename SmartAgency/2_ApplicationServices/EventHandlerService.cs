using SmartAgency._1_Core.Data.Entities.UserEntity.ClientEntity;
using SmartAgency._1_Core.Data.Repositories;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgency._2_ApplicationServices
{
    public class EventHandlerService : IEventHandlerService
    {
        private readonly IRepository<Client> _clientRepository;
        public EventHandlerService(IRepository<Client> clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public void SubscribeToEvents()
        {
            _clientRepository.EntityAdded += ClientRepositoryOnEntityAdded;
            _clientRepository.EntityDeleted += ClientRepositoryOnEntityRemoved;
        }

        private void ClientRepositoryOnEntityAdded(object? entity, Client client)
        {
            AnsiConsole.MarkupLine($"[green] Client {client.FirstName} {client.LastName} succesfully added [/]");
        }

        private void ClientRepositoryOnEntityRemoved (object? entity, Client client)
        {
            AnsiConsole.MarkupLine($"[green] Client {client.FirstName} {client.LastName} succesfully removed [/]");
        }
    }
}
