namespace TollFeeCalculator.Tests;

public class TollCalculator_Tests
{
    private readonly TollCalculator tollCalculator = new();

    [Fact]
    public void GetTollFeeForTime_ChristmasDay()
    {
        Assert.Equal(0, tollCalculator.GetTollFeeForTime(new DateTime(2023,12,25), new Car()));
    }
}