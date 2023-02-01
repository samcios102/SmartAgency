using SmartAgency._1_Core.Data.Entities.UserEntity;

namespace SmartAgency._2_ApplicationServices.Components.DataProviders;

public interface IUserProvider<TUser> where TUser : UserBase
{
    List<TUser> Search(string searchValue);

    List<TUser> SortByDateAdded (bool ascending);

    List<TUser> FilterAddedAfterDate(DateOnly date);

    List<TUser> ShowBasicColumn();



}