using SmartAgency.Data.Entities.ContractEntity;
using SmartAgency.Data.Entities.Enums;
using SmartAgency.Data.Entities.ValueObjects;

namespace SmartAgency.Data.Entities.PropertyEntity;

public record Property
{
    public Property(
        int price, 
        Localisation localisation, 
        int rooms, 
        double squareMetres,
        TechnicalCondition technicalCondition)
    {
        Price = price;
        Localisation = localisation;
        Rooms = rooms;
        SquareMetres = squareMetres;
        TechnicalCondition = technicalCondition;
    }

    public int Price { get; }
    public Localisation Localisation { get; }
    public int Rooms { get; }
    public double SquareMetres { get; }
    public TechnicalCondition TechnicalCondition { get; }

}