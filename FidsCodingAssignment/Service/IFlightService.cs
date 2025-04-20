using FidsCodingAssignment.Model;
using FidsCodingAssignment.ViewModel;

namespace FidsCodingAssignment.Service
{
    public interface IFlightService
    {
        Task AddFlightsAsync(List<FlightDataModel> list);
        //Task<string> CheckFlightStatusAsync(int flightId);
        Task<FlightViewModel> CheckFlightStatusAsync(int flightId);
        Task<List<FlightViewModel>> GetActiveFlightsAtGateAsync(string gateCode);
        Task<List<FlightViewModel>> GetDelayedFlightsAsync(int delta, DateTime currentDateTime);
    }
}
