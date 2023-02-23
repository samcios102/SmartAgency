using SmartAgency._1_Core.Data.Entities.UserEntity;

namespace SmartAgency._3_UI.UserOperations
{
    public interface IUserOperations<TUser> where TUser : UserBase
    {
        void RenderOperations();

        void ShowUsers();
        void SearchUsers();

        void SortByDateAdded();

        void FilterAddedAfterDate();

        void AddUser();

        void DeleteUser();

        void LoadUsersFromCsv();






    }
}
