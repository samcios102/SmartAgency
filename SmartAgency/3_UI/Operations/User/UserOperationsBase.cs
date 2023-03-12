using SmartAgency._1_Core.Data.Entities.UserEntity;
using SmartAgency._1_Core.Data.Entities.UserEntity.ClientEntity;
using SmartAgency._1_Core.Data.Repositories;
using SmartAgency._2_ApplicationServices.Components.CsvReader;
using SmartAgency._2_ApplicationServices.Components.DataProviders;
using SmartAgency._2_ApplicationServices.Components.DataProviders.Extensions;
using Spectre.Console;

namespace SmartAgency._3_UI.UserOperations;

public class UserOperationsBase<TUser> : IUserOperations<TUser> where TUser : UserBase, new()
{
    private readonly IUserProvider<TUser> _userProvider;
    private readonly IRepository<TUser> _userRepository;
    private readonly ICsvReader<TUser> _csvReader;
    private readonly string _type = typeof(TUser).Name;

    public UserOperationsBase
        (
        IUserProvider<TUser> userProvider,
        IRepository<TUser> userRepository,
        ICsvReader<TUser> csvReader
        )
    {
        _userProvider = userProvider;
        _userRepository = userRepository;
        _csvReader = csvReader;
    }

    public virtual void RenderOperations()
    {
        var table = new Table();

        table.AddColumn("[blue] Number [/]");
        table.AddColumn("[orange1] Operation [/]");
        table.AddRow("1",$"Show all {typeof(TUser).Name}s");
        table.AddRow("2",$"Search for {typeof(TUser).Name}");
        table.AddRow("3",$"Sort {typeof(TUser).Name} by date added");
        table.AddRow("4",$"Show {typeof(TUser).Name} added after specific date");
        table.AddRow("5",$"Add new {typeof(TUser).Name}");
        table.AddRow("6",$"Delete {typeof(TUser).Name}");
        table.AddRow("7", $"Add {_type} from csv file");
        table.AddRow("8", "[red] Exit [/]");

        AnsiConsole.Write(table);
    }


    public virtual void AddUser()
    {

        var firstName = GetUserInput("first name");
        var lastName = GetUserInput("last name");
        var email = GetUserInput("email");

        var user = new TUser
        {
            Id = Guid.NewGuid(),
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            DateAdded = DateOnly.FromDateTime(DateTime.Today)
        };

        _userRepository.Add(user);

        _userRepository.Save();
    }

    public virtual void DeleteUser()
    {
        Console.Clear();

        AnsiConsole.MarkupLine($"[red] Type user to delete [/]");
        var queryString = Console.ReadLine();

        var user = _userProvider.Search(queryString).FirstOrDefault();

        if (user is null)
        {
            AnsiConsole.MarkupLine("Name of user is not valid");
            Console.ReadLine();
            return;
        }

        AnsiConsole.Confirm($"Do you want delete user below? \n {user}");

        _userRepository.Remove(user.Id);
        _userRepository.Save();

    }


    public virtual void SortByDateAdded()
    {
        Console.Clear();

        var ascOrDesc = AnsiConsole.Confirm("Choose \"y\" to ascending sort or \"n\" to descending sort");


        var users = _userProvider.SortByDateAdded(ascOrDesc);

        PrintUsers(users);
    }


    public virtual void FilterAddedAfterDate()
    {
        Console.Clear();
        AnsiConsole.MarkupLine($"[blue] Enter date after clients were added in format dd-mm-yyyy [/]");
        
        var afterDate = Console.ReadLine();

        var dateValidFormat = false;
        do
        {
            if (DateOnly.TryParse(afterDate, out DateOnly dateParsed))
            {
                dateValidFormat = true;

                var users = _userProvider.FilterAddedAfterDate(dateParsed);

                PrintUsers(users);
            }
            else
            {
                AnsiConsole.MarkupLine($"[blue] Enter date in valid format dd-mm-yyyy (example: 12-30-1999) [/]");
                afterDate = Console.ReadLine();
            }

        } while (!dateValidFormat);

    }



    public virtual void ShowUsers()
    {
        Console.Clear();

        var users = _userProvider.ShowBasicColumn();


        PrintUsers(users);

    }


    public virtual void SearchUsers()
    {
     
        Console.Clear();
        AnsiConsole.MarkupLine("[green] Type query string[/]");

        var queryString = Console.ReadLine();

        if (String.IsNullOrEmpty(queryString))
        {
            AnsiConsole.MarkupLine("[red] Query string is empty[/]");
            return;
        }

        var users = _userProvider.Search(queryString);

        
        PrintUsers(users);
        
    }

    public virtual void LoadUsersFromCsv()
    {
        Console.Clear();
        AnsiConsole.MarkupLine($"[green] Type file name from 1_Core\\Resources\\Files catalog in format: <fileName>.csv[/]");

        var fileName = Console.ReadLine();

        if (String.IsNullOrEmpty(fileName))
        {
            AnsiConsole.MarkupLine("[red] File name cannot be empty[/]");
            return;
        }

        var usersToAdd = _csvReader.ProcessClients($"1_Core\\Resources\\Files\\" + fileName);
        var count = 0;

        foreach (var user in usersToAdd)
        {
            _userRepository.Add(user);
            count++;
        }

        _userRepository.Save();

        AnsiConsole.MarkupLine($"Added {count} records");
        Console.ReadLine();
    }
    




    private void PrintUser(TUser user)
    {
        Console.Clear();

        if (user is null)
        {
            AnsiConsole.MarkupLine($"[red] No {typeof(TUser).Name} found [/]");
            return;
        }

        AnsiConsole.MarkupLine($"[yellow] {typeof(TUser).Name} found: [/]");
        AnsiConsole.WriteLine($"{user}");
        Console.ReadLine();
    }

    private void PrintUsers(IEnumerable<TUser> getUsers)
    {

        if (!getUsers.Any() || getUsers is null)
        {
            
            AnsiConsole.MarkupLine($"[red] No {typeof(TUser).Name} found! [/]");
            Console.ReadLine();
            return;
        }

        if (getUsers.Count() == 1)
        {
            PrintUser(getUsers.First());
            return;
        }

        var users = getUsers.ToList();


        Console.Clear();
        AnsiConsole.MarkupLine($"[yellow] {typeof(TUser).Name}s found:[/]");

        if (users.Count() < 20)
        {
            
            foreach (var user in users)
            {
                AnsiConsole.MarkupLine($"{user} ");
            }

            Console.ReadLine();

        }
        else
        {
            Paging(users);
        }
        
    }
    

    private void Paging(IEnumerable<TUser> users)
    {

        var pages = users.Count() / 20 + 1;
        
        do
        {

            var pageNrIsInt = false;

            do
            {
                AnsiConsole.MarkupLine($"[blue] Write page number (max {pages}) [/]");
                var pageNumberString = Console.ReadLine();


                if (int.TryParse(pageNumberString, out int pageNumberInt))
                {
                    var usersOnPage = users.ShowPage(pageNumberInt);

                    foreach (var user in usersOnPage)
                    {
                        AnsiConsole.WriteLine($"{user} ");
                    }
                    pageNrIsInt = true;
                }
                else
                {
                    AnsiConsole.MarkupLine($"[red] Page number must be integer [/]");
                }
                
            } while (!pageNrIsInt);


        } while (AnsiConsole.Confirm("Do you want look for other page?"));
        
        
    }

    private static string GetUserInput(string type)
    {
        Console.Clear();
        AnsiConsole.MarkupLine($"[green] Type user {type} [/]");
        return Console.ReadLine();
    }



}