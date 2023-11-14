namespace AutomotiveBrands.Lib.Cache.Services.Redis
{
    public interface IRedisService
    {
        /// <summary>
        /// Is there data from the cache
        /// </summary>
        /// <param name="cacheKey">cache key</param>
        /// <exception cref="ArgumentNullException">when no cache key</exception>
        Task<bool> ExistsAsync(string cacheKey);

        /// <summary>
        /// Increment
        /// </summary>
        /// <param name="cacheKey">cache key</param>
        /// <param name="increment">increment value</param>
        /// <returns>total result</returns>
        /// <exception cref="ArgumentNullException">when no cache key</exception>
        Task<int> IncrementAsync(string cacheKey, int increment);

        /// <summary>
        /// Decrement
        /// </summary>
        /// <param name="cacheKey">cache key</param>
        /// <param name="increment">decrement value</param>
        /// <returns>total result</returns>
        /// <exception cref="ArgumentNullException">when no cache key</exception>
        Task<int> DecrementAsync(string cacheKey, int increment);

        /// <summary>
        /// Hash get all
        /// </summary>
        /// <param name="cacheKey">key group</param>
        /// <returns>type of hash entry array</returns>
        Task<HashEntry[]> HashGetAllAsync(string cacheKey);

        /// <summary>
        /// Hash get
        /// </summary>
        /// <param name="cacheKey">key group</param>
        /// <param name="hashField">key</param>
        /// <returns>type of hash value</returns>
        Task<TModel> HashGetAsync<TModel>(string cacheKey, string hashField);

        /// <summary>
        /// Hash set
        /// </summary>
        /// <param name="cacheKey">key group</param>
        /// <param name="hashField">key</param>
        /// <param name="value">value</param>
        Task<bool> HashSetAsync(string cacheKey, string hashField, string value);

        /// <summary>
        /// Hash delete
        /// </summary>
        /// <param name="cacheKey">key group</param>
        /// <param name="hashField">key</param>
        Task<bool> HashDeleteAsync(string cacheKey, string hashField);

        /// <summary>
        /// Sorted set increment
        /// </summary>
        /// <param name="cacheKey">cache keys</param>
        /// <param name="memberKey">member key</param>
        /// <param name="increment">increment value</param>
        Task<int> SortedSetIncrementAsync(string cacheKey, string memberKey, int increment = 1);

        /// <summary>
        /// Get sorted list by score
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <param name="cacheKey">cache keys</param>
        /// <param name="start">start score</param>
        /// <param name="stop">stop score</param>
        /// <param name="order">default: descending</param>
        /// <returns>type of T list</returns>
        Task<List<T>> GetSortedListByScoreAsync<T>(string cacheKey, int start = 0, int stop = -1, Order order = Order.Descending) where T : struct;

        /// <summary>
        /// Get data from cache (asynchronous) 
        /// </summary>
        /// <typeparam name="TModel">data type</typeparam>
        /// <param name="cacheKey">cache key</param>
        /// <returns>type of TModel</returns>
        Task<TModel> GetAsync<TModel>(string cacheKey);

        /// <summary>
        /// insert data to cache (asynchronous)
        /// </summary>
        /// <typeparam name="TModel">data type</typeparam>
        /// <param name="cacheKey">cache key</param>
        /// <param name="value">data</param>
        /// <exception cref="ArgumentNullException">when no cache key</exception>
        Task<bool> SetAsync<TModel>(string cacheKey, TModel value);

        /// <summary>
        /// insert data to cache (asynchronous)
        /// </summary>
        /// <typeparam name="TModel">data type</typeparam>
        /// <param name="cacheKey">cache key</param>
        /// <param name="value">data</param>
        /// <param name="absoluteExpiration">absolute expiration minute, default: indefinite</param>
        /// <exception cref="ArgumentNullException">when no cache key</exception>
        Task<bool> SetWithExpiryDateAsync<TModel>(string cacheKey, TModel value, AbsoluteExpiration absoluteExpiration);

        /// <summary>
        /// insert data to cache (asynchronous)
        /// </summary>
        /// <typeparam name="TModel">data type</typeparam>
        /// <param name="cacheKey">cache key</param>
        /// <param name="value">data</param>
        /// <param name="absoluteExpiration">absolute expiration minute, default: indefinite</param>
        /// <exception cref="ArgumentNullException">when no cache key</exception>
        Task<bool> SetWithExtendDateAsync<TModel>(string cacheKey, TModel value, int minute = 5);

        /// <summary>
        /// Extend cache key time
        /// </summary>
        /// <param name="cacheKey">cache key</param>
        /// <param name="minute">minute - default : five minute</param>
        Task<bool> ExtendCacheKeyTimeAsync(string cacheKey, int minute = 5);

        /// <summary>
        /// Delete data from cache (asynchronous) 
        /// </summary>
        /// <param name="cacheKey">cache key</param>
        /// <exception cref="ArgumentNullException">when no cache key</exception>
        Task<bool> RemoveAsync(string cacheKey);

        /// <summary>
        /// Remove keys by search key
        /// </summary>
        /// <param name="searchKey">redis key pattern</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">when no search key</exception>
        Task<bool> RemoveKeysBySearchKeyAsync(string searchKey, KeySearchType keySearchType);

        /// <summary>
        /// Clear app cache
        /// </summary>
        /// <remarks>database number</remarks>
        /// <returns></returns>
        ValueTask ClearAppCacheAsync(int databaseNumber = default);
    }
}
