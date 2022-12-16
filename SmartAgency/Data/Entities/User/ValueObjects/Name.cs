namespace SmartAgency.Data.Entities.User.ValueObjects;


public record Name
{
    public string Value { get; } // powinno być immutable

    public Name(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("Both users names cannot be empty");
        }

        Value = value;


    }

    public static implicit operator Name(string value)
        => new(value);

    public static implicit operator string(Name name)
        => name.Value;


}
