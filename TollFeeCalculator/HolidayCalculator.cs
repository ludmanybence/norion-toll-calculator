using System.Security.Cryptography;

namespace TollFeeCalculator;

public class HolidayCalculator
{
    public bool IsHoliday(DateTime date)
    {
        return IsFixedDateHoliday(date) || IsSwedishMidsummer(date) || IsEasterRelatedHoliday(date);
    }

    public bool IsSwedishMidsummer(DateTime date)
    {
        return false;
    }

    public bool IsFixedDateHoliday(DateTime date)
    {
        return false;
    }

    public bool IsEasterRelatedHoliday(DateTime date)
    {
        var easter = CalculateEaster(date.Year);
        var easterMonday = easter.AddDays(1);
        var goodFriday = easter.AddDays(-2);
        var ascensionDay = easter.AddDays(39);
        var pentecost = easter.AddDays(49);

        return date == easter || date == easterMonday || date == goodFriday || date == ascensionDay || date == pentecost;
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