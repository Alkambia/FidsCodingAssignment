namespace FidsCodingAssignment.Service
{
    public interface ICacheService
    {
        Task AddOrUpdateAsync<T>(T data, TimeSpan? expiration = null);
        Task<T?> GetAsync<T>() where T : class;
    }
}
