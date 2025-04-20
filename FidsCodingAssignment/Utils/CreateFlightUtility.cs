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
                ActualTime = flightdata.ActualTime,
                AirLineCode = flightdata.AirLineCode,
                FlightNumber = flightdata.FlightNumber,
                CityName = flightdata.CityName,
                GateId = flightdata.GateCode,
                BoardingTime = false,
                FlightDirection = flightdata.ArrDep.Equals("DEP") ? FlightDirection.Departing : FlightDirection.Arriving,
            };


            if (flight.FlightDirection == FlightDirection.Departing)
            {
                var boardingWindowInMinutes = int.Parse(configuration["Flight:BoardingWindowInMinutes"]);
                var thresholdInMinutes = int.Parse(configuration["Flight:ThresholdInMinutes"]);
                if (flight.ActualTime >= flight.SchedTime && flight.ActualTime <= flight.SchedTime.Value.AddMinutes(boardingWindowInMinutes) 
                    || flight.ActualTime < flight.SchedTime)
                {
                    flight.BoardingTime = true;
                    flight.FlightStatus = "Boarding";
                }
                //note: I jus assume DateTime.Now is the current time
                else if (flight.ActualTime.HasValue && DateTime.Now >= flight.ActualTime.Value.AddMinutes(thresholdInMinutes))
                {
                    flight.FlightStatus = "Closed";
                }
            }

            //note: note sure if its the correct implementation
            var delta = int.Parse(configuration["Flight:Delta"]);
            var deltaBefore = TimeSpan.FromMinutes(-1 * delta); // Predefined delta
            var deltaAfter = TimeSpan.FromMinutes(delta); // Predefined delta
            var timeBefore = flight.ActualTime + deltaBefore;
            var timeAfter = flight.ActualTime + deltaAfter;

            flight.IsCurrentlyAtGate = flight.ActualTime.HasValue && timeBefore <= flight.ActualTime.Value && flight.ActualTime.Value <= timeAfter;
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
