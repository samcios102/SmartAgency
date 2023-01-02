using ClientCSV = SmartAgency._2_ApplicationServices.Components.CsvReader.Models.ClientCSV;

namespace SmartAgency._2_ApplicationServices.Components.CsvReader;

public interface ICsvReader
{
    List<ClientCSV> ProcessClients(string filePath);

}