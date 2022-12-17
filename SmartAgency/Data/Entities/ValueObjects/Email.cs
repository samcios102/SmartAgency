using System.ComponentModel.DataAnnotations;

namespace SmartAgency.Data.Entities.ValueObjects;

public record Email
{

    public string Value { get; }

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

    // nie trzeba var new Name(name)

    public static implicit operator Email(string value) // z prymitywu na value object // tak naprawde to jest kontruktor taki
        => new(value);

    public static implicit operator string(Email email) // z value na prymityw
        => email.Value;



}