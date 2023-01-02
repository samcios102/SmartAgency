using SmartAgency._2_ApplicationServices.Components.CsvReader.Extensions;
using SmartAgency._2_ApplicationServices.Components.CsvReader.Models;

namespace SmartAgency._2_ApplicationServices.Components.CsvReader;

public class CsvReader : ICsvReader
{
    public List<ClientCSV> ProcessClients(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new Exception("Wrong filepath to Client CSV");
        }

        var clients = File.ReadAllLines(filePath)
            .Skip(1)
            .Where(x => x.Length > 1)
            .ToClientsCsv();

        return clients.ToList();
    }
}