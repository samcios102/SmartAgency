using System.ComponentModel.DataAnnotations;
using Spectre.Console;

namespace SmartAgency._1_DataAccess.Data.Entities.ValueObjects;

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

        if (!isValid)
        {
            do
            {
                AnsiConsole.MarkupLine("Enter email in valid format");

                value = Console.ReadLine();

                isValid = new EmailAddressAttribute().IsValid(value);

            } while (!isValid);
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