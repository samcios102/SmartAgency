using SmartAgency._1_Core.Data.Entities.UserEntity;
using SmartAgency._1_Core.Data.Repositories;
using SmartAgency._3_UI.UserOperations;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgency._2_ApplicationServices.Services.UserInteractions
{
    public class UserInteractions<TUser> : IUserInteractions<TUser> where TUser : UserBase
    {
        private readonly IUserOperations<TUser> _userOperations;

        public UserInteractions(IUserOperations<TUser> userOperations)
        {
            _userOperations = userOperations;
        }


        public void ChooseActions()
        {
            var selection = "";


            do
            {
                Console.Clear();

                _userOperations.RenderOperations();
                AnsiConsole.MarkupLine($"[orange1] Select operation: [/]");

                selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        _userOperations.ShowUsers();
                        break;
                    case "2":
                        _userOperations.SearchUsers();
                        break;
                    case "3":
                        _userOperations.SortByDateAdded();
                        break;
                    case "4":
                        _userOperations.FilterAddedAfterDate();
                        break;
                    case "5":
                        _userOperations.AddUser();
                        break;
                    case "6":
                        _userOperations.DeleteUser();
                        break;
                    case "7":
                        _userOperations.LoadUsersFromCsv();
                        break;
                    case "8":
                        break;

                }

            } while (selection is not "8");
        }

    }
}
