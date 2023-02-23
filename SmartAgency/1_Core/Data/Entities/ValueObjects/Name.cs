
using SmartAgency._1_Core.Data.ValueConverters;
using System.ComponentModel;

namespace SmartAgency._1_Core.Data.Entities.ValueObjects;

[TypeConverter(typeof(NameConverter))]
public class Name
{
    public string Value { get; set; } // powinno być immutable

/*    public Name()
    {
        Value = "";
    }*/
    public Name(string value)
    {
        if (string.IsNullOrEmpty(value) )
        {
            throw new ArgumentException("Both users names cannot be empty");
        }



        Value = value;


    }

    public Name() // due to serialize 
    {

    }

    public static implicit operator Name(string value)
        => new(value);

    public static implicit operator string(Name name)
        => name.Value;

    public override string ToString()
    {
        return Value;
    }
}
