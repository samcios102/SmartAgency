using SmartAgency._1_Core.Data.Entities.ValueObjects;

namespace SmartAgency._1_Core.Data.Entities.UserEntity.ClientEntity;

public record Client : UserBase
{
    
    public Client(Guid id, Name firstName, Name lastName, Email email, DateOnly dateAdded)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        DateAdded = dateAdded;
    }

    public Client()
    {

    }

    public override string ToString()
    {
        return base.ToString();
    }
}
