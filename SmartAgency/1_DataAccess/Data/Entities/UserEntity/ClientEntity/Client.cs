using SmartAgency.Data.Entities.ContractEntity;
using SmartAgency.Data.Entities.ValueObjects;

namespace SmartAgency.Data.Entities.UserEntity.ClientEntity;

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
