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

    private readonly int dailyCap = 60;

    /**
     * Calculate the total toll fee for one day
     *
     * @param vehicle - the vehicle
     * @param dates   - date and time of all passes on one day
     * @return - the total toll fee for that day
     */
    public int GetTotalTollFeeForDates(Vehicle vehicle, DateTime[] dates)
    {
        if (IsTollFreeVehicle(vehicle)) return 0;

        DateTime intervalStart = new(dates[0].Year, dates[0].Month, dates[0].Day, 0, 0, 0);
        int previousPayment = 0;
        int totalFee = 0;

        foreach (DateTime date in dates)
        {
            if (date >= intervalStart.AddHours(1) || previousPayment == 0)
            {
                var fee = GetTollFeeForTime(date, vehicle);
                intervalStart = date;
                previousPayment = fee;
                totalFee+=fee;
            }
        }

        return Math.Min(dailyCap, totalFee);
    }

    public int GetTollFeeForTime(DateTime date, Vehicle vehicle)
    {
        if (IsTollFreeDate(date) || IsTollFreeVehicle(vehicle)) return 0;

        DateTime today = DateTime.Today;
        DateTime timeOfDay = new(today.Year, today.Month, today.Day, date.Hour, date.Minute, 0);

        var price = 0;

        foreach (var item in TimeTable.PriceTable)
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
        return date.Month == 7 || date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday || HolidayCalculator.IsHoliday(date) || HolidayCalculator.IsHoliday(date.AddDays(1));
    }
}