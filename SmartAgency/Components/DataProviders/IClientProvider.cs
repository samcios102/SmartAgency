using SmartAgency.Data.Entities.UserEntity.ClientEntity;

namespace SmartAgency.Components.DataProviders;

public interface IClientProvider
{
    List<Client> SearchClients(string searchValue);

    List<Client> SortClientByDateAdded (bool ascending);

    List<Client> FilterClientsAddedAfterDate(DateOnly date);

    List<Client> ShowBasicColumn();

    List<Client> ShowPage(int pageNr);


}