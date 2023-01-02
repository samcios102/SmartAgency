using SmartAgency._1_DataAccess.Data.Entities.UserEntity.ClientEntity;
using SmartAgency._2_ApplicationServices.Components.CsvReader.Models;

namespace SmartAgency._2_ApplicationServices.Components.CsvReader.Extensions
{
    public static class ClientCsvExtension
    {
        public static IEnumerable<ClientCSV> ToClientsCsv(this IEnumerable<string> source)
        {
            return source.Select(line => line.Split(',')).Select(columns => new ClientCSV
                {
                    Id = Guid.Parse(columns[0]),
                    FirstName = columns[1],
                    LastName = columns[2],
                    Email = columns[3],
                    DateAdded = DateOnly.Parse(columns[4])
                }
            );
        }

        public static Client ToClient(this ClientCSV clientCsv)
        {
            return new Client
            {
                Id = clientCsv.Id,
                FirstName = clientCsv.FirstName,
                LastName = clientCsv.LastName,
                Email = clientCsv.Email,
                DateAdded = clientCsv.DateAdded
            };

        }

    }
}
