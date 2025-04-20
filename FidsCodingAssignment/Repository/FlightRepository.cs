using FidsCodingAssignment.Enums;
using FidsCodingAssignment.Model;
using FidsCodingAssignment.Service;

namespace FidsCodingAssignment.Repository
{
    public class FlightRepository : IFlightRepository
    {
        private readonly ICacheService _cacheService;
        public FlightRepository(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public async Task AddAsync(List<Flight> flights)
        {
            await _cacheService.AddOrUpdateAsync(flights);
        }

        public async Task<Flight?> GetAsync(int flightId)
        {
            var flights = await _cacheService.GetAsync<List<Flight>>();
            var flight = flights?.FirstOrDefault(c => c.FlightId == flightId);

            if (flight == null)
                return null;

            return flight;
        }

        public async Task<List<Flight>> GetAsync(string gateId)
        {
            var flights = await _cacheService.GetAsync<List<Flight>>();
            if(flights == null)
                return new List<Flight>();

            return flights.Where(c => c.GateId == gateId && c.IsCurrentlyAtGate).ToList();
        }

        //note: I assume delta is the deltaThreshold
        public async Task<List<Flight>> GetDelayedFlights(int deltaThreshold, DateTime currentTime)
        {
            var flights = await _cacheService.GetAsync<List<Flight>>();
            if (flights == null)
                return new List<Flight>();

            var thresholdTime = currentTime.AddMinutes(deltaThreshold);
            return flights.Where(f => thresholdTime > f.SchedTime.Value).ToList();
        }
    }
}
