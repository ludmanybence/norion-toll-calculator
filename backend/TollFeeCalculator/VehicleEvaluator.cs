namespace TollFeeCalculator;

public class VehicleEvaluator : IVehicleEvaluator
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

    public bool IsTollFreeVehicle(Vehicle vehicle)
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
}