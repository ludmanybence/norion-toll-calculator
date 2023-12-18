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

            if (timeOfDay <= intervalEnd && timeOfDay >= intervalStart)
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
        return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday || HolidayCalculator.IsHoliday(date) || HolidayCalculator.IsHoliday(date.AddDays(1));
    }
}