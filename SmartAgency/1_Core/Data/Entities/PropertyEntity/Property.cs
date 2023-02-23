using SmartAgency._1_Core.Data.Entities.Enums;
using SmartAgency._1_Core.Data.Entities.ValueObjects;

namespace SmartAgency._1_Core.Data.Entities.PropertyEntity;

public record Property : IEntity
{
    public int Price { get; set; }
    public Localisation Localisation { get; set; }
    public int Rooms { get; set; }
    public double SquareMetres { get; set; }
    public TechnicalCondition TechnicalCondition { get; set; }

    public Guid Id { get; init; }

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
        Id = Guid.NewGuid();
    }

    public Property()
    {

    }

    /*public override string ToString()
    {
        return v => v string.Join(", ", v);
    }*/
}