using SmartAgency.Data.Entities.UserEntity.ClientEntity;

namespace SmartAgency.Components.DataProviders;

public interface IClientProvider
{
    List<Client> ShowClients();
    List<Client> SearchClients(string searchValue);

    List<Client> SortClients(int chooseOption);

    List<Client> FilterClients();

    List<Client> GetSpecificColumns(int chooseOption);
}