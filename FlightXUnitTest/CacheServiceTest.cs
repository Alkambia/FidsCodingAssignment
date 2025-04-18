using FidsCodingAssignment.Model;
using FidsCodingAssignment.Repository;
using FidsCodingAssignment.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightXUnitTest
{
    public class CacheServiceTest
    {
        [Fact]
        public async void Add_Or_Update_Test()
        {
            //Arrange
            var app = Utility.GetApp();

            var distributableCache = app.Services.GetService<IDistributedCache>();
            var config = app.Services.GetService<IConfiguration>();
            var service = new CacheService(distributableCache, config);
            var data = new Flight {
                FlightId = 1
            };
            //Act
            await service.AddOrUpdateAsync(data);
            var fromCache = await service.GetAsync<Flight>();

            //Assert
            Assert.Equal(data.FlightId, fromCache.FlightId);
        }
    }
}
