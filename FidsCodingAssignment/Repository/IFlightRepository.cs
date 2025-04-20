using FidsCodingAssignment.Enums;
using FidsCodingAssignment.Model;

namespace FidsCodingAssignment.Repository
{
    public interface IFlightRepository
    {
        Task AddAsync(List<Flight> flights);
        Task<Flight?> GetAsync(int flightId);
        Task<List<Flight>> GetAsync(string gateId);
        Task<List<Flight>> GetDelayedFlights(int delta, DateTime? currentTime);
    }
}
