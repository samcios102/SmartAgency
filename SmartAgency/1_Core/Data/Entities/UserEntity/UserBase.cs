using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartAgency._1_Core.Data.Entities.ValueObjects;

namespace SmartAgency._1_Core.Data.Entities.UserEntity;

public abstract record UserBase : IEntity
{
    public Guid Id { get; init; }
    public Name FirstName { get; set; }
    public Name LastName { get; set; }
    public Email Email { get; set; }
    [Required]
    public DateOnly DateAdded { get; set; }

    public UserBase(){}

    public override string ToString()
    {
        return $"{FirstName} {LastName} {Email} {DateAdded}";
    }



}





//comparer i toString

// copy/ clone

// var user1 = user2 with { FirstName = "Gary}


// dont need to serializa and deserialize json ... no more :D
