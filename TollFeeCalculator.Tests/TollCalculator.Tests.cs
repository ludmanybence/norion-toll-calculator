namespace TollFeeCalculator.Tests;

public class TollCalculator_Tests
{
    private readonly TollCalculator tollCalculator = new TollCalculator();

    [Fact]
    public void GetTollFee_ChristmasDay()
    {
        Assert.Equal(0, tollCalculator.GetTollFee(new DateTime(2023,12,25), new Car()));
    }
}