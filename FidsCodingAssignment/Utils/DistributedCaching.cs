using Microsoft.Extensions.Caching.Distributed;

namespace FidsCodingAssignment.Utils
{
    public static class DistributedCaching
    {
        public async static Task SetAsync<T>(this IDistributedCache distributedCache, string key, T value, DateTimeOffset offset)
        {
            await distributedCache.SetAsync(key, value.ToByteArray(), new DistributedCacheEntryOptions()
            {
                AbsoluteExpiration = offset,
            });
        }

        public async static Task<T> GetAsync<T>(this IDistributedCache distributedCache, string key, CancellationToken token = default(CancellationToken)) where T : class
        {
            var result = await distributedCache.GetAsync(key, token);
            return result.FromByteArray<T>();
        }
        
    }
}
