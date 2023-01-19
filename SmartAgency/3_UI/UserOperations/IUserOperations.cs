using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartAgency._1_DataAccess.Data.Entities.UserEntity;

namespace SmartAgency._3_UI
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






    }
}
