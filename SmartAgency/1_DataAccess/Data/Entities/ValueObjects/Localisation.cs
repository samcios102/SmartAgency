using Microsoft.EntityFrameworkCore;
using SmartAgency.Data.Entities.Enums;

namespace SmartAgency.Data.Entities.ValueObjects;
public class Localisation 
{
    public LocalisationDistrict District { get; set; }
    public string StreetName { get; set; }
    public int? StreetNumber { get; set; }
    public int? HouseNumber { get; set; }

    public Localisation()
    {
    }
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

    public override string ToString() => $"{District}, {StreetName}, {StreetNumber}, {HouseNumber}";

    public static explicit operator Localisation(string stringToConvert)
    {
        var stringArray = stringToConvert.Split(',', StringSplitOptions.TrimEntries);

        if (string.IsNullOrEmpty(stringArray[2]))
        {
            return new Localisation { District = Enum.Parse<LocalisationDistrict>(stringArray[0]), StreetName = stringArray[1]};
        }

        if (string.IsNullOrEmpty(stringArray[3]))
        {
            return new Localisation { District = Enum.Parse<LocalisationDistrict>(stringArray[0]), StreetName = stringArray[1], StreetNumber = int.Parse(stringArray[2])};

        }

        return new Localisation(Enum.Parse<LocalisationDistrict>(stringArray[0]), stringArray[1], int.Parse(stringArray[2]), int.Parse(stringArray[3]));
       
        
    }
}