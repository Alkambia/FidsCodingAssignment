using FidsCodingAssignment.Model;
using FidsCodingAssignment.Repository;
using FidsCodingAssignment.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlightXUnitTest
{
    public class FlightServiceTests
    {
        [Fact]
        public async void Add_Flights_Test()
        {
            //Arrange
            var app = Utility.GetApp();

            var repo = app.Services.GetService<IFlightRepository>();
            var config = app.Services.GetService<IConfiguration>();
            var flightService = new FlightService(repo, config);
            var data = Utility.GetFlightsData;

            //Act
            await flightService.AddFlightsAsync(data);

            //Assert
            var flight = await flightService.CheckFlightStatusAsync(541420706);
            Assert.Equal(541420706, flight.FlightId);
        }

        [Fact]
        public async void Check_Flight_Status_Test()
        {
            //Arrange
            var app = Utility.GetApp();

            var repo = app.Services.GetService<IFlightRepository>();
            var config = app.Services.GetService<IConfiguration>();
            var flightService = new FlightService(repo, config);
            var data = Utility.GetFlightsData;
            await flightService.AddFlightsAsync(data);

            //Act
            var result = await flightService.CheckFlightStatusAsync(541420706);

            //Assert
            Assert.Equal("Boarding", result.FlightStatus);
        }

        [Fact]
        public async void Get_Active_Flights_At_Gate_Test()
        {
            //Arrange
            var app = Utility.GetApp();
            var repo = app.Services.GetService<IFlightRepository>();
            var config = app.Services.GetService<IConfiguration>();
            var flightService = new FlightService(repo, config);
            var data = Utility.GetFlightsData;
            await flightService.AddFlightsAsync(data);

            //Act
            var result = await flightService.GetActiveFlightsAtGateAsync("E32");

            //Assert
            Assert.Equal(541420706, result.First().FlightId);
        }

        [Fact]
        public async void Get_Delayed_FlightsTest()
        {
            //Arrange
            var app = Utility.GetApp();
            var repo = app.Services.GetService<IFlightRepository>();
            var config = app.Services.GetService<IConfiguration>();
            var flightService = new FlightService(repo, config);
            var data = Utility.GetFlightsData;
            await flightService.AddFlightsAsync(data);

            //Act
            var result = await flightService.GetDelayedFlightsAsync(2, DateTime.Now);

            //Assert
            Assert.Equal(505, result.FirstOrDefault(c => c.FlightId == 541406104).FlightNumber);
        }
    }
}