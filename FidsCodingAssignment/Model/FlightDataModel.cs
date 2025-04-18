using System.Text.Json.Serialization;

namespace FidsCodingAssignment.Model
{
    public class FlightDataModel
    {
        [JsonPropertyName("flightid")]
        public int FlightId { get; set; }

        [JsonPropertyName("sched_time")]
        public DateTime? SchedTime { get; set; }

        [JsonPropertyName("arrdep")]
        public string? ArrDep { get; set; }

        [JsonPropertyName("actual_time")]
        public DateTime? ActualTime { get; set; }

        [JsonPropertyName("airlinecode")]
        public string? AirLineCode { get; set; }

        [JsonPropertyName("flightnumber")]
        public int FlightNumber { get; set; }

        [JsonPropertyName("parentflightid")]
        public int ParentFlightId { get; set; }

        [JsonPropertyName("city_name")]
        public string? CityName { get; set; }

        [JsonPropertyName("gatecode")]
        public string? GateCode { get; set; }

        [JsonPropertyName("flightstatuscode")]
        public string? FlightStatusCode { get; set; }

        //todo:
        [JsonPropertyName("aircraftregnumber")]
        public string? AirCraftRegNumber { get; set; }

        [JsonPropertyName("airportcode")]
        public string? AirPortcode { get; set; }

        [JsonPropertyName("aircrafttype")]
        public string? AirCraftType { get; set; }

        [JsonPropertyName("tail")]
        public string? Tail { get; set; }

        [JsonPropertyName("terminalcode")]
        public string? TerminalCode { get; set; }

        [JsonPropertyName("airline_name")]
        public string? AirlineName { get; set; }

        [JsonPropertyName("parentairlinecode")]
        public string? ParentAirlineCode { get; set; }

        [JsonPropertyName("parentfltnumber")]
        public int ParentFltNumber { get; set; }

        [JsonPropertyName("estimated_time")]
        public DateTime? EstimatedTime { get; set; }

        [JsonPropertyName("remarks")]
        public string? Remarks { get; set; }

        [JsonPropertyName("parrentsuffix")]
        public string? ParrentSuffix { get; set; }

        [JsonPropertyName("suffix")]
        public string? Suffix { get; set; }

        [JsonPropertyName("viaairportcodes")]
        public string? ViaAirPortCodes { get; set; }

        [JsonPropertyName("eventtime")]
        public string? EventTime { get; set; }

        [JsonPropertyName("flighttype")]
        public string? FlightType { get; set; }

        [JsonPropertyName("event")]
        public string? Event { get; set; }

        [JsonPropertyName("dep_boardingstart_dtm")]
        public DateTime? DepBoardingStartDtm { get; set; }

        [JsonPropertyName("bagbelt")]
        public string? BagBelt { get; set; }

        [JsonPropertyName("remote_airport_sch_dtm")]
        public DateTime? RemoteAirportSchDtm { get; set; }

        [JsonPropertyName("remote_airport_act_dtm")]
        public DateTime? RemoteAirportActDtm { get; set; }

        [JsonPropertyName("remote_airport_est_dtm")]
        public DateTime? RemoteAirportEstDtm { get; set; }
    }
}
