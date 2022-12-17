using SmartAgency.Data.Entities.ValueObjects;

namespace SmartAgency.Data.Entities.UserEntity;

public abstract record User(Guid Id, Name FirstName, Name LastName, Email Email, DateOnly DateAdded) : EntityBase(Id)
{
    /*
    public Name FirstName;
    public Name LastName;
    public Email Email;
    public DateOnly DateAdded;
    */

}





//comparer i toString

// copy/ clone

// var user1 = user2 with { FirstName = "Gary}


// dont need to serializa and deserialize json ... no more :D
