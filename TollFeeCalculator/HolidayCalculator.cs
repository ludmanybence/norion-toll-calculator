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
        return false;
    }
}