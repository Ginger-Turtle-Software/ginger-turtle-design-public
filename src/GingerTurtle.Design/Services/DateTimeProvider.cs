using GingerTurtle.Design.Contracts;

namespace GingerTurtle.Design.Services;

public class DateTimeProvider(int dateTimeUtcOffsetMinutes) : IDateTimeProvider
{
    public string PrettyPrintLocalDate(DateTime? utc)
    {
        if (utc == null)
            return "";
        var local = ConvertToLocalDateTimeFromUtc(utc.GetValueOrDefault()); 
        return local.ToString("dd/MM/yyyy");
    }

    public string PrettyPrintLocalDateTime(DateTime? utc)
    {
        if (utc == null)
            return "";
        var local = ConvertToLocalDateTimeFromUtc(utc.GetValueOrDefault());
        return local.ToString($"dd/MM/yyyy HH:mm");
    }

    public DateTime ConvertToLocalDateTimeFromUtc(DateTime utc)
    {
        var offset = TimeSpan.FromMinutes(dateTimeUtcOffsetMinutes); // offset is negative in JavaScript
        return utc.Add(offset);
    }
}