namespace TollFeeCalculator.Tests;

file record ExpectedTollPriceForTime(int ExpectedPrice, DateTime Time);

file class TestTables
{
    public static ExpectedTollPriceForTime[] RegularRates() => [
        new ExpectedTollPriceForTime(ExpectedPrice: 0, Time: new(2023,12,15, 3,29,59)),
        new ExpectedTollPriceForTime(ExpectedPrice: 8, Time: new(2023,12,15, 6,29,59)),
        new ExpectedTollPriceForTime(ExpectedPrice: 13, Time: new(2023,12,14, 6,30,00)),
        new ExpectedTollPriceForTime(ExpectedPrice: 18, Time: new(2023,12,13, 7,03,05)),
        new ExpectedTollPriceForTime(ExpectedPrice: 13, Time: new(2023,12,15, 8,00,00)),
        new ExpectedTollPriceForTime(ExpectedPrice: 8, Time: new(2023,12,15, 14,20,25)),
        new ExpectedTollPriceForTime(ExpectedPrice: 8, Time: new(2023,12,15, 14,59,59)),
        new ExpectedTollPriceForTime(ExpectedPrice: 13, Time: new(2023,12,15, 15,00,00)),
        new ExpectedTollPriceForTime(ExpectedPrice: 18, Time: new(2023,12,15, 16,25,05)),
        new ExpectedTollPriceForTime(ExpectedPrice: 13, Time: new(2023,12,15, 17,25,05)),
        new ExpectedTollPriceForTime(ExpectedPrice: 8, Time: new(2023,12,15, 18,25,05)),
        new ExpectedTollPriceForTime(ExpectedPrice: 0, Time: new(2023,12,15, 19,25,05)),
    ];

    public static DateTime[] Holidays() => [
        //2013
        new(2013,1,1, 8,00,00),
        new(2013,1,6, 8,00,00),
        new(2013,3,29, 14,59,59),
        new(2013,3,31, 14,59,59),
        new(2013,4,1, 15,00,00),
        new(2013,5,1, 14,59,59),
        new(2013,5,9, 15,00,00),
        new(2013,6,6, 17,25,05),
        new(2013,6,22, 18,25,05),
        new(2013,11,1, 18,25,05),
        new (2013,12,25, 6,29,59),
        new(2013,12,26, 6,30,00),
        //2023
        new(2013,1,1, 8,00,00),
        new(2013,1,6, 8,00,00),
        new(2013,4,7, 14,59,59),
        new(2013,4,9, 14,59,59),
        new(2013,4,10, 15,00,00),
        new(2013,5,1, 14,59,59),
        new(2013,5,18, 15,00,00),
        new(2013,6,6, 17,25,05),
        new(2013,6,24, 18,25,05),
        new(2013,11,4, 18,25,05),
        new (2013,12,25, 6,29,59),
        new(2013,12,26, 6,30,00),
    ];

    public static DateTime[] Weekends() => [
        new(2023,1,21, 8,00,00),
        new(2023,1,22, 8,00,00),
        new(2023,9,2, 14,59,59),
        new(2023,9,3, 14,59,59),
        new(2023,9,16, 15,00,00),
        new(2023,9,17, 14,59,59),
        new(2023,10,07, 15,00,00),
        new(2023,10,08, 17,25,05),
        new(2023,11,25, 18,25,05),
        new(2023,11,26, 18,25,05),
        new(2023,12,16, 6,29,59),
        new(2023,12,17, 6,30,00),
    ];
}

public class TollCalculator_Tests
{
    private readonly TollCalculator tollCalculator = new();

    [Fact]
    public void GetTollFeeForTime_Car_Weekdays()
    {
        Vehicle vehicle = new Vehicle(VehicleType.Car);

        foreach (var item in TestTables.RegularRates())
        {
            Assert.Equal(item.ExpectedPrice, tollCalculator.GetTollFeeForTime(item.Time, vehicle));
        }
    }

    [Fact]
    public void GetTollFeeForTime_Car_Weekends()
    {
        Vehicle vehicle = new Vehicle(VehicleType.Car);

        foreach (var time in TestTables.Weekends())
        {
            Assert.Equal(0, tollCalculator.GetTollFeeForTime(time, vehicle));
        }
    }

    [Fact]
    public void GetTollFeeForTime_Car_DayBeforeHolidays()
    {
        Vehicle vehicle = new Vehicle(VehicleType.Car);

        foreach (var time in TestTables.Holidays())
        {
            Assert.Equal(0, tollCalculator.GetTollFeeForTime(time.AddDays(-1), vehicle));
        }
    }

    [Fact]
    public void GetTollFeeForTime_Car_Holidays()
    {
        Vehicle vehicle = new Vehicle(VehicleType.Motorbike);
        foreach (var time in TestTables.Holidays())
        {
            Assert.Equal(0, tollCalculator.GetTollFeeForTime(time, vehicle));
        }
    }

    [Fact]
    public void GetTollFeeForTime_Motorbike_Weekdays()
    {
        Vehicle vehicle = new Vehicle(VehicleType.Motorbike);

        foreach (var item in TestTables.RegularRates())
        {
            Assert.Equal(0, tollCalculator.GetTollFeeForTime(item.Time, vehicle));
        }
    }

    [Fact]
    public void GetTollFeeForTime_Motorbike_Weekends()
    {
        Vehicle vehicle = new Vehicle(VehicleType.Motorbike);

        foreach (var time in TestTables.Weekends())
        {
            Assert.Equal(0, tollCalculator.GetTollFeeForTime(time, vehicle));
        }
    }

    [Fact]
    public void GetTollFeeForTime_Motorbike_Holidays()
    {
        Vehicle vehicle = new Vehicle(VehicleType.Motorbike);

        foreach (var time in TestTables.Holidays())
        {
            Assert.Equal(0, tollCalculator.GetTollFeeForTime(time, vehicle));
        }
    }

    [Fact]
    public void GetTollFeeForTime_Motorbike_DayBeforeHolidays()
    {
        Vehicle vehicle = new Vehicle(VehicleType.Motorbike);

        foreach (var time in TestTables.Holidays())
        {
            Assert.Equal(0, tollCalculator.GetTollFeeForTime(time.AddDays(-1), vehicle));
        }
    }

    [Fact]
    public void GetTotalTollFeeForDates_Car_ShouldNotExceedDailyCap()
    {
        var dailyCap = 60;
        Vehicle vehicle = new Vehicle(VehicleType.Car);

        var passageTimes = TestTables.RegularRates().Select(x => x.Time).ToArray();
        var total = tollCalculator.GetTotalTollFeeForDates(vehicle, passageTimes);

        Assert.True(total <= dailyCap);
    }

    [Fact]
    public void GetTotalTollFeeForDates_Car_ShouldNotChargeMoreThanOncePerHour()
    {
        Vehicle vehicle = new Vehicle(VehicleType.Car);

        DateTime[] passageTimes = [
            new(2023,12,15,8,29,0),
            new(2023,12,15,8,39,0),
            new(2023,12,15,8,59,0),
            new(2023,12,15,9,28,0),
        ];
        var total = tollCalculator.GetTotalTollFeeForDates(vehicle, passageTimes);

        Assert.Equal(13, total);
    }

    [Fact]
    public void GetTotalTollFeeForDates_Car_ShouldChargeAgainIfMoreThanOneHourPassed()
    {
        Vehicle vehicle = new Vehicle(VehicleType.Car);
    
        DateTime[] passageTimes = [
            new(2023,12,15,8,29,0),
            new(2023,12,15,9,39,0),
        ];
        var total = tollCalculator.GetTotalTollFeeForDates(vehicle, passageTimes);

        Assert.Equal(21, total);
    }

    [Fact]
    public void GetTotalTollFeeForDates_Car_ShouldNotBeCharged_Holidays()
    {
        Vehicle vehicle = new Vehicle(VehicleType.Car);

        var total = tollCalculator.GetTotalTollFeeForDates(vehicle, TestTables.Holidays());

        Assert.Equal(0, total);
    }

    [Fact]
    public void GetTotalTollFeeForDates_Car_ShouldNotBeCharged_Weekends()
    {
        Vehicle vehicle = new Vehicle(VehicleType.Car);

        var total = tollCalculator.GetTotalTollFeeForDates(vehicle, TestTables.Weekends());

        Assert.Equal(0, total);
    }

    [Fact]
    public void GetTotalTollFeeForDates_Motorbike_ShouldNotBeCharged()
    {
        Vehicle vehicle = new Vehicle(VehicleType.Motorbike);

        var passageTimes = TestTables.RegularRates().Select(x => x.Time).ToArray();
        var total = tollCalculator.GetTotalTollFeeForDates(vehicle, passageTimes);

        Assert.Equal(0, total);
    }
}