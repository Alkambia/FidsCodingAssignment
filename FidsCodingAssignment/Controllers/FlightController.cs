using FidsCodingAssignment.Model;
using FidsCodingAssignment.Service;
using Microsoft.AspNetCore.Mvc;

namespace FidsCodingAssignment.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FlightController : ControllerBase
    {
        private IFlightService _flightService;
        public FlightController(IFlightService flightService) {
            _flightService = flightService;
        }

        [HttpPost(Name = "Create")]
        public async Task<IActionResult> Create(GateLoungeFlightModel data)
        {
            await _flightService.AddFlightsAsync(data.Flights);
            return Ok();
        }


        [HttpGet(Name = "GetFlightStatus")]
        public async Task<IActionResult> GetFlightStatusAsync(int flightId)
        {
            //todo: return only status or entity with status?
            var file = await _flightService.CheckFlightStatusAsync(flightId);
            return Ok(file);
        }

        [HttpGet(Name = "GetActiveFlightsAtGate")]
        public async Task<IActionResult> GetActiveFlightsAtGateAsync(string gateId)
        {
            var activeFlights = await _flightService.GetActiveFlightsAtGateAsync(gateId);
            return Ok(activeFlights);
        }

        [HttpGet(Name = "GetDelayedFlights")]
        public async Task<IActionResult> GetDelayedFlightsAsync(int delta)
        {
            var delayedFlights = await _flightService.GetDelayedFlightsAsync(delta);
            return Ok(delayedFlights);
        }


    }
}
