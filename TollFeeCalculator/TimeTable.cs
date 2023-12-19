namespace TollFeeCalculator;

public record Time(int Hour, int Minute);
public record Interval(Time Start, Time End);
public record PriceForInterval(int Price, Interval Interval);

public static class TimeTable
{
    public readonly static PriceForInterval[] PriceTable = [
        new (Price:8, Interval:new (Start:new (6,0), End:new (6,29))),
        new (Price:13, Interval:new (Start:new (6,30), End:new (6,59))),
        new (Price:18, Interval:new (Start:new (7,0), End:new (7,59))),
        new (Price:13, Interval:new (Start:new (8,0), End:new (8,29))),
        new (Price:8, Interval:new (Start:new (8,30), End:new (14,59))),
        new (Price:13, Interval:new (Start:new (15,0), End:new (15,29))),
        new (Price:18, Interval:new (Start:new (15,30), End:new (16,59))),
        new (Price:13, Interval:new (Start:new (17,0), End:new (17,59))),
        new (Price:8, Interval:new (Start:new (18,0), End:new (18,29))),
        ];
}