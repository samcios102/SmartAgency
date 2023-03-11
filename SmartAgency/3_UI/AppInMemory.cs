using SmartAgency._1_Core.Data.Entities.UserEntity.ClientEntity;
using SmartAgency._1_Core.Data;
using SmartAgency._2_ApplicationServices.Services.UserInteractions;
using SmartAgency._2_ApplicationServices;
using SmartAgency._3_UI.UserOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgency._3_UI
{
    public class AppInMemory : IApp
    {
        private readonly IUserOperations<Client> _clientOperations;
        private readonly IUserInteractions<Client> _clientInteractions;
        private readonly IEventHandlerService _eventHandlerService;
        private readonly SmartAgencyAppDbContextInMemory _dbContext; // MS SQL - needed?

        public AppInMemory(
            IUserOperations<Client> clientOperations,
            IUserInteractions<Client> clientInteractions,
            IEventHandlerService eventHandler,
            SmartAgencyAppDbContextInMemory dbContext // MS SQL - needed?
            )
        {
            _clientOperations = clientOperations;
            _clientInteractions = clientInteractions;
            _eventHandlerService = eventHandler;
            _dbContext = dbContext; // MS SQL - needed?
        }

        public void Run()
        {

            _eventHandlerService.SubscribeToEvents();
            _clientInteractions.ChooseActions();

 
        }
    }
}

