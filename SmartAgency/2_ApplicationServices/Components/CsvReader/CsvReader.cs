using SmartAgency._1_Core.Data.Entities.UserEntity;
using SmartAgency._2_ApplicationServices.Components.CsvReader.Models;

namespace SmartAgency._2_ApplicationServices.Components.CsvReader;

public class CsvReader<TUser> : ICsvReader<TUser> where TUser : UserBase, new()
{
    public List<TUser> ProcessClients(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new Exception("Wrong filepath to Client CSV");
        }

        var users = File.ReadAllLines(filePath)
            .Skip(1)
            .Where(x => x.Length > 1);

        return ToUserFromCsv(users).ToList();
    }

    private static IEnumerable<TUser> ToUserFromCsv(IEnumerable<string> source)
    {
        return source.Select(line => line.Split(',')).Select(columns => new TUser()
            {
                Id = Guid.Parse(columns[0]),
                FirstName = columns[1],
                LastName = columns[2],
                Email = columns[3],
                DateAdded = DateOnly.Parse(columns[4])
            }
        );
    }
}