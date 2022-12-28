using SmartAgency.Data.Entities.ValueObjects;

namespace SmartAgency.Data.Entities.UserEntity;

public abstract record User : IEntity
{
    public Guid Id { get; init; }
    public Name FirstName { get; set; }
    public Name LastName { get; set; }
    public Email Email { get; set; }
    public DateOnly DateAdded { get; set; }

    public User(){}

}





//comparer i toString

// copy/ clone

// var user1 = user2 with { FirstName = "Gary}


// dont need to serializa and deserialize json ... no more :D
