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
                var boardingWindowInMinutes = int.Parse(configuration["Flight:BoardingWindowInMinutes"]);
                var thresholdInMinutes = int.Parse(configuration["Flight:ThresholdInMinutes"]);
                var timespanx =  flight.ActualTime - flight.SchedTime;
                //CurrentTime? I assume its the current time
                if (flight.ActualTime < DateTime.Now || flight.ActualTime >= (DateTime.Now.AddMinutes(-boardingWindowInMinutes)))
                {
                    flight.BoardingTime = true;
                    flight.FlightStatus = "Boarding";
                }

                if (flight.ActualTime > (DateTime.Now.AddMinutes(thresholdInMinutes)))
                {
                    flight.FlightStatus = "Closed";
                }

                var currentActualTime = flight.ActualTime.HasValue ? flight.ActualTime : DateTime.Now;
                var delta = int.Parse(configuration["Flight:Delta"]);
                var timeBefore = currentActualTime + TimeSpan.FromMinutes(-1 * delta); //before
                var timeAfter = currentActualTime + TimeSpan.FromMinutes(delta); //after

                flight.IsCurrentlyAtGate = timeBefore <= currentActualTime && currentActualTime <= timeAfter;
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
