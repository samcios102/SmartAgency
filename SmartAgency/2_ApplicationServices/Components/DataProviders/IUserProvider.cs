using SmartAgency.Data.Entities.UserEntity;
using SmartAgency.Data.Entities.UserEntity.ClientEntity;
using User = SmartAgency.Data.Entities.UserEntity.User;

namespace SmartAgency.Components.DataProviders;

public interface IUserProvider<TUser> where TUser : User
{
    List<TUser> Search(string searchValue);

    List<TUser> SortByDateAdded (bool ascending);

    List<TUser> FilterAddedAfterDate(DateOnly date);

    List<TUser> ShowBasicColumn();

    List<TUser> ShowPage(int pageNr);


}