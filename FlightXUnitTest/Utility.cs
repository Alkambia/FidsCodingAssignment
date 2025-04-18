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
                return new List<FlightDataModel> {
                    new FlightDataModel{
                        FlightId = 541420706,
                        SchedTime = DateTime.Now,
                        ArrDep = "DEP",
                        ActualTime = DateTime.Now,
                        AirLineCode = "NK",
                        FlightNumber = 163,
                        ParentFlightId = 0,
                        CityName = "Atlanta",
                        GateCode = "E32",
                        FlightStatusCode = "",
                        AirCraftRegNumber = "N948NK",
                        AirPortcode = "",
                        AirCraftType = "",
                        Tail = "",
                        TerminalCode = "",
                        AirlineName = "",
                        ParentAirlineCode = "",
                        ParentFltNumber = 0,
                        EstimatedTime = DateTime.Now,
                        Remarks = "On Time",
                        ParrentSuffix = "0",
                        Suffix = "0",
                        ViaAirPortCodes = "",
                        EventTime = "",
                        FlightType = "D",
                        Event = "",
                        DepBoardingStartDtm = DateTime.Now,
                        BagBelt = "",
                        RemoteAirportSchDtm = DateTime.Now,
                        RemoteAirportActDtm = DateTime.Now,
                        RemoteAirportEstDtm = DateTime.Now
                    },
                    new FlightDataModel{
                        FlightId = 541406104,
                        SchedTime = DateTime.Parse("2023-08-08T13:00:00Z"),
                        ArrDep = "DEP",
                        ActualTime = DateTime.Parse("2023-08-08T12:49:00Z"),
                        AirLineCode = "SY",
                        FlightNumber = 505,
                        ParentFlightId = 0,
                        CityName = "Cancun MX",
                        GateCode = "",
                        FlightStatusCode = "",
                        AirCraftRegNumber = "N822SY",
                        AirPortcode = "CUN",
                        AirCraftType = "B738",
                        Tail = "",
                        TerminalCode = "",
                        AirlineName = "SUN COUNTRY",
                        ParentAirlineCode = "",
                        ParentFltNumber = 0,
                        EstimatedTime = DateTime.Parse("2023-08-08T12:49:00Z"),
                        Remarks = "At 7:49a",
                        ParrentSuffix = "0",
                        Suffix = "0",
                        ViaAirPortCodes = "",
                        EventTime = "",
                        FlightType = "D",
                        Event = "",
                        DepBoardingStartDtm = DateTime.Now,
                        BagBelt = "",
                        RemoteAirportSchDtm = DateTime.Now,
                        RemoteAirportActDtm = DateTime.Now,
                        RemoteAirportEstDtm = DateTime.Now
                    }
                };
            }
        }
    }
}
