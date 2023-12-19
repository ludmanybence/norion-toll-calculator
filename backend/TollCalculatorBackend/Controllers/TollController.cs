using Microsoft.AspNetCore.Mvc;
using TollCalculatorAPI.DTOs;
using TollFeeCalculator;

namespace TollCalculatorAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class TollController : ControllerBase
{
    [HttpPost]
    public IActionResult GetTollTotal(TollRequestDTO request)
    {
        var tollCalculator = TollCalculator.Default();

        VehicleType vehicleType;
        Enum.TryParse(request.VehicleType, out vehicleType);

        var passagesInOrder = request.Passages.OrderDescending().Reverse().Select(x => x.ToLocalTime()).ToArray();
        var res = tollCalculator.GetTotalTollFeeForDates(new(vehicleType), passagesInOrder);

        var response = new TollDTO
        {
            Price = res
        };

        return Ok(response);
    }
}