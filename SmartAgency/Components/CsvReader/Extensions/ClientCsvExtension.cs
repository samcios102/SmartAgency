using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartAgency.Components.CsvReader.Models;
using SmartAgency.Data.Entities.UserEntity.ClientEntity;

namespace SmartAgency.Components.CsvReader.Extensions
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
