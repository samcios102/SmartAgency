using SmartAgency.Data.Entities.ContractEntity;
using SmartAgency.Data.Entities.ValueObjects;

namespace SmartAgency.Data.Entities.UserEntity.ClientEntity;

public record Client : User
{
    /*    (Guid Id, Name FirstName, Name LastName, Email Email, DateOnly DateAdded)
        : User(Id, FirstName, LastName, Email, DateAdded)*/

/*    public Guid Id { get; set; }
    public Name FirstName { get; set; }
    public Name LastName { get; set; }
    public Email Email { get; set; }
    public DateOnly DateAdded { get; set; }*/

    public Client()
    {

    }

}
