using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartAgency.Components.CsvReader.Models;

namespace SmartAgency.Components.CsvReader.Extensions
{
    public static class ClientExtension
    {
        public static IEnumerable<ClientCSV> ToClient(this IEnumerable<string> source)
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
    }
}
