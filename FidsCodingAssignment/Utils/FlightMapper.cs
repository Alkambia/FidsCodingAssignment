using FidsCodingAssignment.Enums;
using FidsCodingAssignment.Model;
using FidsCodingAssignment.ViewModel;

namespace FidsCodingAssignment.Utils
{
    public static class FlightMapper
    {
        public static FlightViewModel ToViewModel(this Flight flight)
        {
            if (flight == null)
                return new FlightViewModel();

            return new FlightViewModel
            {
                FlightId = flight.FlightId,
                SchedTime = flight.SchedTime,
                ActualTime = flight.ActualTime,
                AirLineCode = flight.AirLineCode,
                FlightNumber = flight.FlightNumber,
                CityName = flight.CityName,
                GateId = flight.GateId,
                BoardingTime = flight.BoardingTime,
                FlightStatus = flight.FlightStatus,
                IsCurrentlyAtGate = flight.IsCurrentlyAtGate,
                FlightDirection = flight.FlightDirection.ToDescription()
            };
        }

        public static List<FlightViewModel> ToViewModel(this List<Flight> flights)
        {
            if (flights == null)
                return new List<FlightViewModel>();

            return flights.Select(flight => flight.ToViewModel()).ToList();
        }
    }
}
