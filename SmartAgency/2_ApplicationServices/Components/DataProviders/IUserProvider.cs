using User = SmartAgency._1_DataAccess.Data.Entities.UserEntity.User;

namespace SmartAgency._2_ApplicationServices.Components.DataProviders;

public interface IUserProvider<TUser> where TUser : User
{
    List<TUser> Search(string searchValue);

    List<TUser> SortByDateAdded (bool ascending);

    List<TUser> FilterAddedAfterDate(DateOnly date);

    List<TUser> ShowBasicColumn();

    List<TUser> ShowPage(int pageNr);


}