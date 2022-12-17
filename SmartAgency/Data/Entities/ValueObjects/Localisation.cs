using SmartAgency.Data.Entities.Enums;

namespace SmartAgency.Data.Entities.ValueObjects;

public record Localisation
{
    public LocalisationDistrict District { get; }
    public string StreetName { get; }
    public int? StreetNumber { get; }
    public int? HouseNumber { get; }
    public Localisation(LocalisationDistrict district, string streetName, int? streetNumber, int? houseNumber)
    {

        if (string.IsNullOrEmpty(streetName))
        {
            throw new ArgumentException("Street Name cannot be empty");
        }


        District = district;
        StreetName = streetName;
        StreetNumber = streetNumber;
        HouseNumber = houseNumber;

    }







}