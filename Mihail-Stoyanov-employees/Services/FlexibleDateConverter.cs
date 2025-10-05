using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Globalization;

namespace Mihail_Stoyanov_employees.Services
{
    public class FlexibleDateConverter : DefaultTypeConverter
    {
        private static readonly string[] Formats = new[]
        {
        "yyyy-MM-dd",
        "yyyy/MM/dd",
        "MM/dd/yyyy",
        "dd/MM/yyyy",
        "yyyy-MM-ddTHH:mm:ss",
        "dd-MMM-yyyy",
        "dd.MM.yyyy"
    };

        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrWhiteSpace(text) || text.Trim().ToUpperInvariant() == "NULL")
                return DateTime.Today;

            text = text.Trim();

            if (DateTime.TryParseExact(text, Formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dt))
                return dt.Date;

            if (DateTime.TryParse(text, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out dt))
                return dt.Date;

            throw new TypeConverterException(this, memberMapData, text, row.Context, $"Could not parse date: '{text}'");
        }
    }
}