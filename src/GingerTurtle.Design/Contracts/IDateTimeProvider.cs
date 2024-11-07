namespace GingerTurtle.Design.Contracts;

public interface IDateTimeProvider
{
    string PrettyPrintLocalDate(DateTime? utc);
    string PrettyPrintLocalDateTime(DateTime? utc);
    DateTime ConvertToLocalDateTimeFromUtc(DateTime utc);
}