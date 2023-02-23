using SmartAgency._1_Core.Data.Entities.UserEntity;
using ClientCSV = SmartAgency._2_ApplicationServices.Components.CsvReader.Models.ClientCSV;

namespace SmartAgency._2_ApplicationServices.Components.CsvReader;

public interface ICsvReader<TUser> where TUser : UserBase
{
    List<TUser> ProcessClients(string filePath);

}