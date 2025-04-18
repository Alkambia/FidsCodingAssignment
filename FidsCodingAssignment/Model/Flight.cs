using FidsCodingAssignment.Enums;

namespace FidsCodingAssignment.Model
{
    [Serializable]
    public class Flight
    {
        public int FlightId { get; set; }
        public DateTime? SchedTime { get; set; }
        public DateTime? ActualTime { get; set; }
        public string AirLineCode { get; set; }
        public int FlightNumber { get; set; }
        public string CityName { get; set; }
        public string GateId { get; set; }
        public bool BoardingTime { get; set; }
        public string FlightStatus { get; set; }
        public FlightDirection FlightDirection { get; set; }

        public bool IsCurrentlyAtGate { get; set; }
    }
}
