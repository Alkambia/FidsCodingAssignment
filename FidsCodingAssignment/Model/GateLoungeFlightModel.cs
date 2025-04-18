using System.Text.Json.Serialization;

namespace FidsCodingAssignment.Model
{
    public class GateLoungeFlightModel
    {

        [JsonPropertyName("DFW GateLounge Flight List")]
        public List<FlightDataModel> Flights { get; set; }
    }
}
