using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartAgency.Data.Entities.UserEntity;
using SmartAgency.Data.Entities.UserEntity.ClientEntity;
using SmartAgency.Data.Repositories;

namespace SmartAgency.Components.DataProviders
{
    public class UserProvider<TUser> : IUserProvider<TUser> where TUser : User, new()
    {
        private readonly IRepository<TUser> _userRepository;

        public UserProvider(IRepository<TUser> userRepository)
        {
            _userRepository = userRepository;
        }


        public List<TUser> Search(string searchValue)
        {
            var guidTryParsed = Guid.TryParse(searchValue, out var newGuid);
            var dateOnlyTryParsed = DateOnly.TryParse(searchValue, out var newDateOnly);

            var users = _userRepository.GetAll()
                .Where(x => 
                    x.Id.Equals(newGuid) ||
                    x.FirstName.Value.Equals(searchValue, StringComparison.InvariantCultureIgnoreCase) || 
                    x.LastName.Value.Equals(searchValue, StringComparison.InvariantCultureIgnoreCase) ||
                    x.Email.Value.Equals(searchValue, StringComparison.InvariantCultureIgnoreCase) ||
                    x.DateAdded.Equals(newDateOnly)
                    );


            return users.ToList();
        }

        public List<TUser> SortByDateAdded(bool ascending)
        {
            var users = _userRepository.GetAll();

            if (ascending)
            {
                return users.OrderBy(x => x.DateAdded)
                    .ThenBy(x => x.LastName.Value)
                    .ToList();
            }
            else
            {
                return users.OrderByDescending(x => x.DateAdded)
                    .ThenBy(x => x.LastName.Value)
                    .ToList();
            }
                
            
        }

        public List<TUser> FilterAddedAfterDate(DateOnly date)
        {

            var users = _userRepository.GetAll()
                .Where(x => x.DateAdded > date);


            return users.ToList();
        }

        public List<TUser> ShowBasicColumn()
        {
            var users = _userRepository.GetAll()
                .Select(x => new TUser
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    DateAdded = x.DateAdded
                });
            return users.ToList();
        }

        public List<TUser> ShowPage(int pageNr)
        {
            var users = _userRepository.GetAll()
                .OrderByDescending(x => x.DateAdded)
                .Skip((pageNr - 1) * 20)
                .Take(20);

            if (!users.Any())
            {
                throw new ArgumentException("Page not found");
            }


            return users.ToList();
        }
    }
}
