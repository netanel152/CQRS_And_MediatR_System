namespace CQRS_And_MediatR_System.Caching
{
    public interface ICacheable
    {
        bool BypassCache { get; }
        string CacheKey { get; }
        int SlidingExpirationInMinutes { get; }
        int AbsoluteExpirationInMinutes { get; }
    }
}
