namespace TollFeeCalculator;

public enum VehicleType
{
    Car,
    Motorbike,
    Tractor,
    Emergency,
    Diplomat,
    Foreign,
    Military
}

public class Vehicle(VehicleType type)
{
    public VehicleType Type { get { return type; } }
}