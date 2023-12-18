namespace TollFeeCalculator;

public interface IVehicleEvaluator
{
    public bool IsTollFreeVehicle(Vehicle vehicle);
}