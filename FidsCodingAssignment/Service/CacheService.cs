using FidsCodingAssignment.Utils;
using Microsoft.Extensions.Caching.Distributed;

namespace FidsCodingAssignment.Service
{
    public class CacheService : ICacheService
    {
        private readonly string _cacheKey = "flights_data";
        private readonly IDistributedCache _cache;
        private readonly IConfiguration _configuration;

        public CacheService(IDistributedCache cache, IConfiguration configuration)
        {
            _cache = cache;
            _configuration = configuration;
        }

        public async Task AddOrUpdateAsync<T>(T data, TimeSpan? expiration = null)
        {
            if (data == null)
                return;

            await _cache.RemoveAsync(_cacheKey);
            var expirationdate = GetExpirationOrDefault(expiration);
            await _cache.SetAsync(_cacheKey, data, new DateTimeOffset(expirationdate));
        }

        public async Task<T?> GetAsync<T>() where T : class
        {
            try
            {
                return await _cache.GetAsync<T>(_cacheKey);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return default;
        }

        private DateTime GetExpirationOrDefault(TimeSpan? expiration = null)
        {
            try
            {
                if (!expiration.HasValue)
                {
                    //todo: configure in appsettings.json file
                    var redis = _configuration.GetSection("App:Cache");
                    expiration = TimeSpan.FromDays(redis.GetValue<int>("RetentionDays"));
                }

                return DateTime.Now.Add(expiration.Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //note: if no config set will default to 3 days
            return DateTime.Now.AddDays(3);
        }
    }
}
