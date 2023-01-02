using SmartAgency._1_DataAccess.Data.Entities.ValueObjects;

namespace SmartAgency._1_DataAccess.Data.Entities.UserEntity.ClientEntity;

public record Client : User
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

}
