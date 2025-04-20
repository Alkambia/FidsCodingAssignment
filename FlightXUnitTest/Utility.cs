using FidsCodingAssignment.Model;
using FidsCodingAssignment.Repository;
using FidsCodingAssignment.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace FlightXUnitTest
{
    public static class Utility
    {
        public static WebApplication GetApp()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Services.AddSingleton<ICacheService, CacheService>();
            builder.Services.AddTransient<IFlightRepository, FlightRepository>();
            builder.Services.AddTransient<IFlightService, FlightService>();
            builder.Services.AddDistributedMemoryCache();
            return builder.Build();
        }

        public static List<FlightDataModel> GetFlightsData
        {
            get
            {
                var onTimeDate = DateTime.Now;
                return new List<FlightDataModel> {
                    //Departing, Depart 30 minutes late
                    new FlightDataModel{
                        FlightId = 541420706,
                        SchedTime = DateTime.Now,
                        ActualTime = DateTime.Now.AddMinutes(30),
                        AirLineCode = "NK",
                        FlightNumber = 162,
                        CityName = "Georgia",
                        GateCode = "E32",
                        ArrDep = "DEP"
                    },
                    //Arriving ontime
                    new FlightDataModel{
                        FlightId = 541420707,
                        SchedTime = onTimeDate,
                        ActualTime = onTimeDate,
                        AirLineCode = "NL",
                        FlightNumber = 163,
                        CityName = "Atlanta",
                        GateCode = "E33",
                        ArrDep = "ARR"
                    },
                    new FlightDataModel{
                        FlightId = 541420708,
                        SchedTime = DateTime.Now.AddMinutes(40),
                        ActualTime = DateTime.Now.AddMinutes(20),
                        AirLineCode = "NM",
                        FlightNumber = 163,
                        CityName = "Athens",
                        GateCode = "E33",
                        ArrDep = "DEP"
                    },
                    new FlightDataModel{
                        FlightId = 541420709,
                        SchedTime = DateTime.Now,
                        ActualTime = DateTime.Now.AddMinutes(31),
                        AirLineCode = "NN",
                        FlightNumber = 164,
                        CityName = "Athens",
                        GateCode = "E34",
                        ArrDep = "DEP"
                    },
                    //Arriving  Late
                    new FlightDataModel{
                        FlightId = 541420710,
                        SchedTime = DateTime.Now,
                        ActualTime = DateTime.Now.AddMinutes(40),
                        AirLineCode = "NO",
                        FlightNumber = 165,
                        CityName = "London",
                        GateCode = "E35",
                        ArrDep = "ARR"
                    },
                    new FlightDataModel{
                        FlightId = 541420711,
                        SchedTime = onTimeDate,
                        ActualTime = onTimeDate,
                        AirLineCode = "NP",
                        FlightNumber = 166,
                        CityName = "Belfast",
                        GateCode = "E36",
                        ArrDep = "DEP"
                    }
                };
            }
        }
    }
}
