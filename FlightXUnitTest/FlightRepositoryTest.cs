﻿using FidsCodingAssignment.Model;
using FidsCodingAssignment.Repository;
using FidsCodingAssignment.Service;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightXUnitTest
{
    public class FlightRepositoryTest
    {
        [Fact]
        public async void Add_Get_FlightID_Test()
        {
            //Arrange
            var app = Utility.GetApp();

            var cacheService = app.Services.GetService<ICacheService>();
            var service = new FlightRepository(cacheService);
            var data = new List<Flight>{
                new Flight
                {
                    FlightId = 1
                } 
            };
            //Act
            await service.AddAsync(data);
            var from_repo = await service.GetAsync(1);

            //Assert
            Assert.Equal(data.First().FlightId, from_repo.FlightId);
        }

        [Fact]
        public async void Get_GateID_Test()
        {
            //Arrange
            var app = Utility.GetApp();

            var cacheService = app.Services.GetService<ICacheService>();
            var service = new FlightRepository(cacheService);
            var data = new List<Flight>{
                new Flight{
                        FlightId = 541406104,
                        SchedTime = DateTime.Parse("2023-08-08T13:00:00Z"),
                        FlightDirection = FidsCodingAssignment.Enums.FlightDirection.Departing,
                        ActualTime = DateTime.Parse("2023-08-08T12:49:00Z"),
                        AirLineCode = "SY",
                        FlightNumber = 505,
                        CityName = "Cancun MX",
                        IsCurrentlyAtGate = true,
                        FlightStatus = "Boardning",
                        BoardingTime = true,
                        GateId = "E32"
                    }
            };
            //Act
            await service.AddAsync(data);
            var from_repo = await service.GetAsync("E32");

            //Assert
            Assert.Equal(data.First().GateId, from_repo.First().GateId);
        }

        [Fact]
        public async void Get_Delayed_Flights_Test()
        {
            //Arrange
            var app = Utility.GetApp();

            var cacheService = app.Services.GetService<ICacheService>();
            var service = new FlightRepository(cacheService);
            var onTimeDate = DateTime.Now;
            var data = new List<Flight> {
                //Departing, Depart 30 minutes late
                new Flight{
                    FlightId = 541420706,
                    SchedTime = DateTime.Now,
                    ActualTime = DateTime.Now.AddMinutes(30),
                    AirLineCode = "NK",
                    FlightNumber = 162,
                    CityName = "Georgia",
                    GateId = "E32",
                    FlightDirection = FidsCodingAssignment.Enums.FlightDirection.Departing
                },
                //Arriving ontime
                new Flight{
                    FlightId = 541420707,
                    SchedTime = onTimeDate,
                    ActualTime = onTimeDate,
                    AirLineCode = "NL",
                    FlightNumber = 163,
                    CityName = "Atlanta",
                    GateId = "E33",
                    FlightDirection = FidsCodingAssignment.Enums.FlightDirection.Arriving
                }
            };
            //Act
            await service.AddAsync(data);
            var from_repo = await service.GetDelayedFlights(2, null);

            //Assert
            Assert.Equal(data.First().GateId, from_repo.First().GateId);
        }
    }
}
