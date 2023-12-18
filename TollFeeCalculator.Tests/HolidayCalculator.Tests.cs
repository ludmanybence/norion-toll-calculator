namespace TollFeeCalculator.Tests;

file record TestDate(string Name, DateTime Date);

file class TestDates
{
    public static readonly TestDate[] FixedHolidays = [
        new("Christmas Eve", new(2009,12,24)),
        new("Christmas Day", new(2010,12,25)),
        new("2nd Day Christmas", new(2011,12,26)),
        new("New Years Eve", new(2011,12,31)),
        new("New Years Day", new(2002,1,1)),
        new("Epiphany", new(2000,1,6)),
        new("Swedish National Day", new(2015,6,6)),
        new("May 1st", new(1985,5,1))
    ];

    public static readonly TestDate[] NonHolidays = [
        new("August 15th", new(2018,8,15)),
        new("February 2nd", new(2010,2,2)),
    ];

    public static readonly TestDate[] EasterSundays = [
        new("Easter Sunday", new(1692,4,6)),
        new("Easter Sunday", new(2044,4,17)),
        new("Easter Sunday", new(2003,4,20)),
    ];

    public static readonly TestDate[] EasterRelatedHolidays = [
        new("Good Friday", new(2084,3,24)),
        new("Good Friday", new(2007,4,6)),
        new("Easter Monday", new(1855,4,9)),
        new("Easter Monday", new(1998,4,13)),
        new("Ascension Day", new(2025,5,29)),
        new("Ascension Day", new(2026,5,14)),
        new("Pentecost", new(2015,5,24)),
        new("Pentecost", new(2007,5,27)),
    ];

    public static readonly TestDate[] MidsommarDays = [
        new("Midsummer Day", new(2024,6,22)),
        new("Midsummer Day", new(2025,6,21)),
        new("Midsummer Day", new(2026,6,20)),
    ];
}

public class HolidayCalculator_Tests
{
    [Fact]
    public void IsFixedDateHoliday_ShouldReturn_True_FixedDateHolidays()
    {
        foreach (var day in TestDates.FixedHolidays)
        {
            Assert.True(HolidayCalculator.IsFixedDateHoliday(day.Date), $"Expected {day.Date} to be a holiday: {day.Name}");
        }
    }

    [Fact]
    public void IsFixedDateHoliday_ShouldReturn_False_NonHolidays()
    {
        foreach (var day in TestDates.NonHolidays)
        {
            Assert.False(HolidayCalculator.IsFixedDateHoliday(day.Date), $"Expected {day.Date} not to be a holiday: {day.Name}");
        }
    }

    [Fact]
    public void IsFixedDateHoliday_ShouldReturn_False_Non_FixedDateHolidays()
    {
        TestDate[] dates = [.. TestDates.EasterSundays, .. TestDates.MidsommarDays, .. TestDates.EasterRelatedHolidays];

        foreach (var day in dates)
        {
            Assert.False(HolidayCalculator.IsFixedDateHoliday(day.Date), $"Expected {day.Date} not to be a fixed date holiday: {day.Name}");
        }
    }

    [Fact]
    public void IsSwedishMidsummer_ShouldReturn_True_MidsummerDays()
    {
        foreach (var day in TestDates.MidsommarDays)
        {
            Assert.True(HolidayCalculator.IsSwedishMidsummer(day.Date), $"Expected {day.Date} to be a holiday: {day.Name}");
        }
    }

    [Fact]
    public void IsSwedishMidsummer_ShouldReturn_False_NonHolidays()
    {
        foreach (var day in TestDates.NonHolidays)
        {
            Assert.False(HolidayCalculator.IsSwedishMidsummer(day.Date), $"Expected {day.Date} not to be Swedish Midsummer: {day.Name}");
        }
    }

    [Fact]
    public void IsSwedishMidsummer_ShouldReturn_False_Non_Midsummer_Holidays()
    {
        TestDate[] dates = [.. TestDates.EasterSundays, .. TestDates.FixedHolidays, .. TestDates.EasterRelatedHolidays];

        foreach (var day in dates)
        {
            Assert.False(HolidayCalculator.IsSwedishMidsummer(day.Date), $"Expected {day.Date} not to be Swedish Midsummer: {day.Name}");
        }
    }

    [Fact]
    public void IsEasterRelatedHoliday_ShouldReturn_True_EasterSundays()
    {
        foreach (var day in TestDates.EasterSundays)
        {
            Assert.True(HolidayCalculator.IsEasterRelatedHoliday(day.Date), $"Expected {day.Date} to be an easter related holiday: {day.Name}");
        }
    }

    [Fact]
    public void IsEasterRelatedHoliday_ShouldReturn_True_EasterRelatedHolidays()
    {
        foreach (var day in TestDates.EasterRelatedHolidays)
        {
            Assert.True(HolidayCalculator.IsEasterRelatedHoliday(day.Date), $"Expected {day.Date} not to be an easter related holiday: {day.Name}");
        }
    }

    [Fact]
    public void IsEasterRelatedHoliday_ShouldReturn_False_Non_EasterRelated_Holidays()
    {
        TestDate[] dates = [.. TestDates.MidsommarDays, .. TestDates.FixedHolidays];

        foreach (var day in dates)
        {
            Assert.False(HolidayCalculator.IsEasterRelatedHoliday(day.Date), $"Expected {day.Date} not to be an easter related holiday: {day.Name}");
        }
    }

    [Fact]
    public void IsEasterRelatedHoliday_ShouldReturn_False_Non_Holidays()
    {
        foreach (var day in TestDates.NonHolidays)
        {
            Assert.False(HolidayCalculator.IsEasterRelatedHoliday(day.Date), $"Expected {day.Date} not to be an easter related holiday: {day.Name}");
        }
    }

    [Fact]
    public void IsHoliday_ShouldReturn_True_For_Holidays()
    {
        TestDate[] dates = [.. TestDates.MidsommarDays, .. TestDates.FixedHolidays, .. TestDates.EasterSundays, .. TestDates.EasterRelatedHolidays];

        foreach (var day in dates)
        {
            Assert.True(HolidayCalculator.IsHoliday(day.Date), $"Expected {day.Date} to be a holiday: {day.Name}");
        }
    }

    [Fact]
    public void IsHoliday_ShouldReturn_False_For_NonHolidays()
    {
        foreach (var day in TestDates.NonHolidays)
        {
            Assert.False(HolidayCalculator.IsHoliday(day.Date), $"Expected {day.Date} not to be a holiday: {day.Name}");
        }
    }
}