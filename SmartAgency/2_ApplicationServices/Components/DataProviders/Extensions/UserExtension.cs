using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartAgency._1_Core.Data.Entities.UserEntity;

namespace SmartAgency._2_ApplicationServices.Components.DataProviders.Extensions
{
    public static class UserExtension
    {
        public static IEnumerable<UserBase> ShowPage(this IEnumerable<UserBase> users, int pageNr)
        {
            var usersOnPage = users
                .OrderByDescending(x => x.DateAdded)
                .Skip((pageNr - 1) * 20)
                .Take(20);

            if (!users.Any())
            {
                throw new ArgumentException("Page not found");
            }

            return usersOnPage;
        }
    }
}
