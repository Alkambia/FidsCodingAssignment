using FidsCodingAssignment.Enums;
using FidsCodingAssignment.Model;

namespace FidsCodingAssignment.Utils
{
    public static class CreateFlightUtility
    {

        public static Flight ToDbFlight(this FlightDataModel flightdata, IConfiguration configuration)
        {
            var flight = new Flight
            {
                FlightId = flightdata.FlightId,
                SchedTime = flightdata.SchedTime,
                //Note: Base on json data if actualtime is null, estimatedtime has value with remarks either late or early.
                ActualTime = flightdata.ActualTime.HasValue ? flightdata.ActualTime : flightdata.EstimatedTime,
                AirLineCode = flightdata.AirLineCode,
                FlightNumber = flightdata.FlightNumber,
                CityName = flightdata.CityName,
                GateId = flightdata.GateCode,
                BoardingTime = false,
                FlightStatus = "",
                FlightDirection = flightdata.ArrDep.Equals("DEP") ? FlightDirection.Departing : FlightDirection.Arriving,
            };

            if (flight.FlightDirection == FlightDirection.Departing)
            {
                var deltaThreshold = int.Parse(configuration["Flight:DeltaThreshold"]);
                var predefinedWindow = int.Parse(configuration["Flight:PreDefinedWindowInMinutes"]); // 30 minutes before scheduled departure time
                flight.BoardingTime = flight.ActualTime < flight.SchedTime || flight.ActualTime >= flight.SchedTime.Value.AddMinutes(-predefinedWindow);

                if (flight.BoardingTime)
                {
                    flight.FlightStatus = "Boarding";
                }
                else if (flight.ActualTime > (flight.SchedTime.Value.AddMinutes(deltaThreshold)))
                {
                    flight.FlightStatus = "Closed";
                }

                flight.IsCurrentlyAtGate = flight.ActualTime >= (flight.SchedTime.Value.AddMinutes(-deltaThreshold))
                    && flight.ActualTime <= (flight.SchedTime.Value.AddMinutes(deltaThreshold));
            }


            return flight;
        }

        public static void ConsolidateCodeShare(this List<FlightDataModel> list)
        {
            var flightsWithParent = list.Where(c => c.ParentFlightId > 0).GroupBy(c => c.ParentFlightId);
            foreach (var flights in flightsWithParent)
            {
                var parentFlightId = flights.Key;
                var parentFlight = list.FirstOrDefault(c => c.FlightId == parentFlightId);

                if (parentFlight != null)
                {
                    foreach (var flight in flights)
                    {
                        UpdateMainFlight(parentFlight, flight.AirLineCode, flight.FlightNumber);
                        list.Remove(flight);
                    }
                }

            }
        }

        private static void UpdateMainFlight(FlightDataModel parentFlight, string airlineCode, int flightNumber)
        {
            parentFlight.AirLineCode = airlineCode;
            parentFlight.FlightNumber = flightNumber;
        }
    }
}
