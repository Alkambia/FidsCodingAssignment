using FidsCodingAssignment.Enums;
using System.Text.Json.Serialization;

namespace FidsCodingAssignment.ViewModel
{
    public class FlightViewModel
    {
        public int FlightId { get; set; }
        public DateTime? SchedTime { get; set; }
        public DateTime? ActualTime { get; set; }
        public string AirLineCode { get; set; }
        public int FlightNumber { get; set; }

        [JsonIgnore]
        public string CityName { get; set; }
        public string GateId { get; set; }
        public bool BoardingTime { get; set; }
        public string FlightStatus { get; set; }
        public bool IsCurrentlyAtGate { get; set; }
        public string FlightDirection { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
