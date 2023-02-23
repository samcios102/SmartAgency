using SmartAgency.Data.Entities.PropertyEntity;
using ClientCSV = SmartAgency.Components.CsvReader.Models.ClientCSV;

namespace SmartAgency.Components.CsvReader;

public interface ICsvReader
{
    List<ClientCSV> ProcessClients(string filePath);

}