using SmartAgency._1_DataAccess.Data.Entities.UserEntity;
using SmartAgency._1_DataAccess.Data.Repositories;
using Spectre.Console;

namespace SmartAgency._2_ApplicationServices.Components.DataProviders
{
    public class UserProvider<TUser> : IUserProvider<TUser> where TUser : UserBase, new()
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
                    x.Email.Value.Equals(searchValue, StringComparison.InvariantCultureIgnoreCase) //||
                    //x.DateAdded.Equals(newDateOnly)
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
                .OrderBy(x => x.DateAdded)
                .Select(x => new TUser
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    DateAdded = x.DateAdded
                });
            return users.ToList();
        }

    }
}
