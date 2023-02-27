using SmartAgency._1_Core.Data.Entities.UserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgency._2_ApplicationServices.Services.UserInteractions
{
    public interface IUserInteractions<TUser> where TUser : UserBase
    {
        void ChooseActions();
    }
}
