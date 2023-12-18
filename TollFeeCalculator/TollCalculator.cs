namespace TollFeeCalculator;

public class TollCalculator
{
    private readonly VehicleType[] TollFreeVehicles =
    [
        VehicleType.Motorbike,
        VehicleType.Tractor,
        VehicleType.Emergency,
        VehicleType.Diplomat,
        VehicleType.Foreign,
        VehicleType.Military
    ];

    /**
     * Calculate the total toll fee for one day
     *
     * @param vehicle - the vehicle
     * @param dates   - date and time of all passes on one day
     * @return - the total toll fee for that day
     */

    public int GetTotalTollFeeForDates(Vehicle vehicle, DateTime[] dates)
    {
        DateTime intervalStart = dates[0];
        int totalFee = 0;
        foreach (DateTime date in dates)
        {
            int nextFee = GetTollFeeForTime(date, vehicle);
            int tempFee = GetTollFeeForTime(intervalStart, vehicle);

            long diffInMillies = date.Millisecond - intervalStart.Millisecond;
            long minutes = diffInMillies / 1000 / 60;

            if (minutes <= 60)
            {
                if (totalFee > 0) totalFee -= tempFee;
                if (nextFee >= tempFee) tempFee = nextFee;
                totalFee += tempFee;
            }
            else
            {
                totalFee += nextFee;
            }
        }
        if (totalFee > 60) totalFee = 60;
        return totalFee;
    }

    public int GetTollFeeForTime(DateTime date, Vehicle vehicle)
    {
        if (IsTollFreeDate(date) || IsTollFreeVehicle(vehicle)) return 0;

        DateTime today = DateTime.Today;
        DateTime timeOfDay = new(today.Year, today.Month, today.Day, date.Hour, date.Minute, 0);

        var price = 0;

        foreach (var item in TimeTable.GetPriceTable())
        {
            DateTime intervalEnd = new(today.Year, today.Month, today.Day, item.Interval.End.Hour, item.Interval.End.Minute, 0);
            DateTime intervalStart = new(today.Year, today.Month, today.Day, item.Interval.Start.Hour, item.Interval.Start.Minute, 0);

            if(timeOfDay <= intervalEnd && timeOfDay >= intervalStart)
            {
                price = item.Price;
            }
        }

        return price;
    }

    private bool IsTollFreeVehicle(Vehicle vehicle)
    {
        foreach (var tfv in TollFreeVehicles)
        {
            if (vehicle.Type == tfv)
            {
                return true;
            }
        }
        return false;
    }

    private bool IsTollFreeDate(DateTime date)
    {
        int year = date.Year;
        int month = date.Month;
        int day = date.Day;

        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;

        if (year == 2013)
        {
            if (month == 1 && day == 1 ||
                month == 3 && (day == 28 || day == 29) ||
                month == 4 && (day == 1 || day == 30) ||
                month == 5 && (day == 1 || day == 8 || day == 9) ||
                month == 6 && (day == 5 || day == 6 || day == 21) ||
                month == 7 ||
                month == 11 && day == 1 ||
                month == 12 && (day == 24 || day == 25 || day == 26 || day == 31))
            {
                return true;
            }
        }
        return false;
    }
}