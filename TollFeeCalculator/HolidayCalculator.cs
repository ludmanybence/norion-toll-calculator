namespace TollFeeCalculator;

file record Holiday(string Name, DateTime Date);

public class HolidayCalculator
{
    public bool IsHoliday(DateTime date)
    {
        return IsFixedDateHoliday(date) || IsSwedishMidsummer(date) || IsEasterRelatedHoliday(date);
    }

    public bool IsSwedishMidsummer(DateTime date)
    {
        return date.Month == 6 && date.Day >= 19 && date.Day <= 26 && date.DayOfWeek == DayOfWeek.Saturday;
    }

    public bool IsFixedDateHoliday(DateTime date)
    {
        return false;
    }

    public bool IsEasterRelatedHoliday(DateTime date)
    {
        var easter = CalculateEaster(date.Year);

        Holiday[] easterHolidays = [
            new("Easter Sunday", easter),
            new("Easter Monday", easter.AddDays(1)),
            new("Good Friday", easter.AddDays(-2)),
            new("Ascension Day", easter.AddDays(39)),
            new("Pentecost Sunday", easter.AddDays(49)),
        ];

        return easterHolidays.Any(x => date == x.Date);
    }

    private DateTime CalculateEaster(int year)
    {
        var a = year % 19;
        var b = year / 100;
        var c = year % 100;
        var d = b / 4;
        var e = b % 4;
        var f = (8 * b + 13) / 25;
        var g = (19 * a + b - d - f + 15) % 30;
        var h = (a + 11 * g) / 319;
        var i = c / 4;
        var j = c % 4;
        var k = (2 * e + 2 * i - j - g + h + 32) % 7;
        var month = (g - h + k + 90) / 25;
        var day = (g - h + k + month + 19) % 32;

        return new DateTime(year, month, day);
    }
}