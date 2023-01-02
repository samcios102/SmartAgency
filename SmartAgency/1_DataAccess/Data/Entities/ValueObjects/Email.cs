using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SmartAgency.Data.Entities.ValueObjects;

public record Email
{

    public string Value { get; set; }

/*    public Email()
    {
        Value = "";
    }*/
    public Email(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentNullException("Email cannot be empty");
        }

        var isValid = new EmailAddressAttribute().IsValid(value);

        if (isValid is false)
        {
            throw new InvalidOperationException("Email is not valid");
        }

        Value = value;
    }


    public static implicit operator Email(string value) 
        => new(value);

    public static implicit operator string(Email email)
        => email.Value;

    public override string ToString()
    {
        return Value;
    }

}