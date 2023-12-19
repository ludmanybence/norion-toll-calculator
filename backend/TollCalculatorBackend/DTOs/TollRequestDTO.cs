using System.Text.Json.Serialization;
using TollFeeCalculator;

namespace TollCalculatorAPI;

public partial class TollRequestDTO{
[JsonPropertyName("vehicleType")]
public string VehicleType { get; set; }="";
[JsonPropertyName("passages")]
public DateTime[] Passages { get; set; } = [];
}