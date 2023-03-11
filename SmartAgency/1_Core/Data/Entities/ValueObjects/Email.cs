using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SmartAgency._1_Core.Data.ValueConverters;
using Spectre.Console;

namespace SmartAgency._1_Core.Data.Entities.ValueObjects;

[TypeConverter(typeof(EmailConverter))]
public record Email
{

    public string Value { get; set; }

    public Email(string value)
    {
        var isValid = new EmailAddressAttribute().IsValid(value);
    
        if (!isValid)
        {
            do
            {
                AnsiConsole.MarkupLine("Enter email in valid format");

                value = Console.ReadLine();

                isValid = new EmailAddressAttribute().IsValid(value);
                string.IsNullOrEmpty(value);

            } while (!isValid);
        }
        

        Value = value;
    }

    public Email() // due to seriale xml
    {

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