
using FidsCodingAssignment.Model;
using FidsCodingAssignment.Repository;
using FidsCodingAssignment.ViewModel;
using FidsCodingAssignment.Utils;

namespace FidsCodingAssignment.Service
{
    public class FlightService: IFlightService
    {

        private readonly IFlightRepository _flightRepository;
        private readonly IConfiguration _configuration;
        public FlightService(IFlightRepository flightRepository, IConfiguration configuration)
        {
            _flightRepository = flightRepository;
            _configuration = configuration;
        }

        public async Task AddFlightsAsync(List<FlightDataModel> list)
        {
            var flights = new List<Flight>();
            list.ConsolidateCodeShare();
            foreach (var flight in list)
            {
                flights.Add(flight.ToDbFlight(_configuration));
            }

            await _flightRepository.AddAsync(flights);
        }

        public async Task<FlightViewModel> CheckFlightStatusAsync(int flightId)
        {
            var flight = await _flightRepository.GetAsync(flightId);
            return flight.ToViewModel();
        }

        public async Task<List<FlightViewModel>> GetActiveFlightsAtGateAsync(string gateId)
        {
            var flights = await _flightRepository.GetAsync(gateId);
            return flights.ToViewModel();
        }

        public async Task<List<FlightViewModel>> GetDelayedFlightsAsync(int delta, DateTime currentDateTime)
        {
            var flights = await _flightRepository.GetDelayedFlights(delta, currentDateTime);
            return flights.ToViewModel();
        }

    }
}
