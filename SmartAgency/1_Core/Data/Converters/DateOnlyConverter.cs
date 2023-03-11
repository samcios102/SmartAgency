using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace SmartAgency._1_Core.Data.Converters
{
    public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    {
        public DateOnlyConverter() : base(
            d => d.ToDateTime(TimeOnly.MinValue),
            d => DateOnly.Parse(DateOnly.FromDateTime(d).ToString("dd.MM.yyyy")))
        {}

    }
    // nie uzywa tego convertera

    //DateOnly.Parse(DateOnly.FromDateTime(d).ToString("dd.MM.yyyy"))
    //DateOnly.FromDateTime(DateTime.Parse(d.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture))
}

//public class DateOnlyStringConverter : ValueConverter<DateOnly, string>
//{
//    public DateOnlyStringConverter() : base(
//        d => d.ToString(),
//        d => DateOnly.Parse(d))
//    { }

//}

    //DateOnly.Parse(DateOnly.FromDateTime(d).ToString("dd.MM.yyyy"))
    //DateOnly.FromDateTime(DateTime.Parse(d.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture))

