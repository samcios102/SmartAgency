namespace SmartAgency._2_ApplicationServices.Components.CsvReader.Models
{
    public class ClientCSV
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateOnly DateAdded { get; set; }

    }
}