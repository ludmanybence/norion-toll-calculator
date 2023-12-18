namespace TollFeeCalculator;

public class DateEvaluator : IDateEvaluator
{
    public bool IsTollFreeDate(DateTime date)
    {
        return date.Month == 7 || date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday || HolidayCalculator.IsHoliday(date) || HolidayCalculator.IsHoliday(date.AddDays(1));
    }
}