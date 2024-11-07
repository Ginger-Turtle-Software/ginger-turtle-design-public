namespace GingerTurtle.Design.Extensions;

public static class DateExtensions
{
    public static int GetDayOfMonth(this DateTime date, int row, int column)
    {
        // Ensure the column is within the range [0, 6] for Monday to Sunday
        if (column is < 0 or > 6)
            return 0;
        

        // Ensure the row is within the range [0, 4]
        if (row is < 0 or > 4)
            return 0;
        
        // Get the first day of the month
        var firstDayOfMonth = new DateOnly(date.Year, date.Month, 1);

        // Find out which day of the week the first day of the month falls on
        var firstDayOfWeek = (int)firstDayOfMonth.DayOfWeek;

        // Adjust for the fact that DateOnly.DayOfWeek returns 0 for Sunday (make Sunday = 7)
        if (firstDayOfWeek == 0) firstDayOfWeek = 7;

        // Calculate the offset from the first day of the month
        int dayOffset = (row * 7) + column - (firstDayOfWeek - 1);

        // Calculate the day number that corresponds to the row and column
        int dayNumber = 1 + dayOffset;

        // Check if the calculated day number is within the valid range for the month
        if (dayNumber < 1 || dayNumber > DateTime.DaysInMonth(date.Year, date.Month))
        {
            return 0;
        }

        return dayNumber;
    }
}