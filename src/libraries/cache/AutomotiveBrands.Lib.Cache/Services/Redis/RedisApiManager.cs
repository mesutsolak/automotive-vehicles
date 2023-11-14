namespace AutomotiveBrands.Lib.Cache.Services.Redis
{
    public sealed class RedisApiManager : IRedisService
    {
        private readonly IDatabase _database;
        private readonly IServer _server;
        private readonly int _defaultDatabase;

        public RedisApiManager(
             IDatabase database,
             IServer server,
             int defaultDatabase)
        {
            _database = database;
            _server = server;
            _defaultDatabase = defaultDatabase;
        }

        public async Task<bool> ExistsAsync(string cacheKey)
        {
            ValidateCacheKey(cacheKey);

            return await RedisRetryPolicies.AsyncRetryPolicy.ExecuteAsync(async () =>
            {
                return await _database.KeyExistsAsync(cacheKey);
            });
        }

        public async Task<int> IncrementAsync(string cacheKey, int increment)
        {
            ValidateCacheKey(cacheKey);

            return await RedisRetryPolicies.AsyncRetryPolicy.ExecuteAsync(async () =>
            {
                var result = await _database.StringIncrementAsync(cacheKey, increment);
                if (0 >= result)
                {
                    Log.Warning("{@cacheKey} anahtar değeri {@increment} kadar arttırılamadı.", cacheKey, increment);
                    return default;
                }

                return Convert.ToInt32(result);
            });
        }

        public async Task<int> DecrementAsync(string cacheKey, int increment)
        {
            ValidateCacheKey(cacheKey);

            return await RedisRetryPolicies.AsyncRetryPolicy.ExecuteAsync(async () =>
            {
                var result = await _database.StringDecrementAsync(cacheKey, increment);
                if (0 >= result)
                {
                    Log.Warning("{@cacheKey} anahtar değeri {@increment} kadar azaltıldı.", cacheKey, increment);
                    return default;
                }

                return Convert.ToInt32(result);
            });
        }

        public async Task<HashEntry[]> HashGetAllAsync(string cacheKey)
        {
            ValidateCacheKey(cacheKey);

            return await RedisRetryPolicies.AsyncRetryPolicy.ExecuteAsync(async () =>
            {
                var hashEntries = await _database.HashGetAllAsync(cacheKey);
                if (hashEntries is null || !hashEntries.Any())
                    return default;

                return hashEntries;
            });
        }

        public async Task<TModel> HashGetAsync<TModel>(string cacheKey, string hashField)
        {
            ValidateCacheKey(cacheKey);

            return await RedisRetryPolicies.AsyncRetryPolicy.ExecuteAsync(async () =>
            {
                var redisValue = await _database.HashGetAsync(cacheKey, hashField);
                if (!redisValue.HasValue)
                    return default;

                return (TModel)Convert.ChangeType(redisValue, typeof(TModel));
            });
        }

        public async Task<bool> HashSetAsync(string cacheKey, string hashField, string value)
        {
            ValidateCacheKey(cacheKey);

            return await RedisRetryPolicies.AsyncRetryPolicy.ExecuteAsync(async () =>
            {
                bool succeeded = await _database.HashSetAsync(cacheKey, hashField, value);
                if (!succeeded)
                {
                    Log.Warning("{@cacheKey} anahtar değerine ait veri redise aktarılamadı.", cacheKey);
                    return default;
                }

                return true;
            });
        }

        public async Task<bool> HashDeleteAsync(string cacheKey, string hashField)
        {
            ValidateCacheKey(cacheKey);

            return await RedisRetryPolicies.AsyncRetryPolicy.ExecuteAsync(async () =>
            {
                bool succeeded = await _database.HashDeleteAsync(cacheKey, hashField);
                if (!succeeded)
                {
                    Log.Warning("{@cacheKey} anahtar değerine ait veri silinemedi.", cacheKey);
                    return default;
                }

                return true;
            });
        }

        public async Task<int> SortedSetIncrementAsync(string cacheKey, string memberKey, int increment = 1)
        {
            ValidateCacheKey(cacheKey);
            ValidateMemberKey(memberKey);

            return await RedisRetryPolicies.AsyncRetryPolicy.ExecuteAsync(async () =>
            {
                var result = await _database.SortedSetIncrementAsync(cacheKey, memberKey, increment);
                if (result == 0)
                {
                    Log.Warning("{@cacheKey} anahtar değerine ait sıralı listede {@memberKey} üyesi güncellenemedi.", cacheKey, memberKey);
                    return default;
                }

                return Convert.ToInt32(result);
            });
        }

        public async Task<List<T>> GetSortedListByScoreAsync<T>(string cacheKey, int start = 0, int stop = -1, Order order = Order.Descending) where T : struct
        {
            ValidateCacheKey(cacheKey);

            return await RedisRetryPolicies.AsyncRetryPolicy.ExecuteAsync(async () =>
            {
                var redisValues = await _database.SortedSetRangeByRankAsync(cacheKey, start, stop, order);
                if (!redisValues.Any())
                {
                    Log.Warning("{@cacheKey} anahtar değerine ait sıralı listede veri bulunamadı. | start: {@start}, stop: {@stop}", cacheKey, start, stop);
                    return default;
                }

                return redisValues.Select(redisValue => (T)Convert.ChangeType(redisValue, typeof(T))).ToList();
            });
        }

        public async Task<TModel> GetAsync<TModel>(string cacheKey)
        {
            ValidateCacheKey(cacheKey);

            return await RedisRetryPolicies.AsyncRetryPolicy.ExecuteAsync(async () =>
            {
                var redisValue = await _database.StringGetAsync(cacheKey);
                if (!redisValue.HasValue)
                    return default;

                if (typeof(TModel) == typeof(string))
                    return (TModel)Convert.ChangeType(redisValue, typeof(TModel));

                return JsonSerializer.Deserialize<TModel>(redisValue);
            });
        }

        public async Task<bool> SetAsync<TModel>(string cacheKey, TModel value)
        {
            ValidateCacheKey(cacheKey);

            return await RedisRetryPolicies.AsyncRetryPolicy.ExecuteAsync(async () =>
            {
                bool succeeded = await _database.StringSetAsync(cacheKey, value.ToConvertJsonIfNotStringType());
                if (!succeeded)
                {
                    Log.Warning("{@cacheKey} adlı veri redise aktarılamadı.", cacheKey);
                    return default;
                }

                return true;
            });
        }

        public async Task<bool> SetWithExpiryDateAsync<TModel>(string cacheKey, TModel value, AbsoluteExpiration absoluteExpiration)
        {
            ValidateCacheKey(cacheKey);

            return await RedisRetryPolicies.AsyncRetryPolicy.ExecuteAsync(async () =>
            {
                bool succeeded = await _database.StringSetAsync(cacheKey, value.ToConvertJsonIfNotStringType());
                if (!succeeded)
                {
                    Log.Warning("{@cacheKey} adlı veri redise aktarılamadı.", cacheKey);
                    return default;
                }

                if (!await _database.KeyExpireAsync(cacheKey, DateTime.Now.AddMinutes(Convert.ToInt32(absoluteExpiration))))
                {
                    Log.Warning("{@cacheKey} adlı cache'e sona erme süresi eklenemedi.", cacheKey);
                    return default;
                }

                return true;
            });
        }

        public async Task<bool> SetWithExtendDateAsync<TModel>(string cacheKey, TModel value, int minute = 5)
        {
            ValidateCacheKey(cacheKey);

            return await RedisRetryPolicies.AsyncRetryPolicy.ExecuteAsync(async () =>
            {
                if (!await _database.KeyExistsAsync(cacheKey))
                {
                    Log.Warning("{@cacheKey} adlı anahtar bulunamadı.", cacheKey);
                    return default;
                }

                var expireTime = await _database.KeyExpireTimeAsync(cacheKey);
                if (!expireTime.HasValue)
                {
                    Log.Warning("{@cacheKey} adlı anahtara ait sona erme süresi bulunamadı.", cacheKey);
                    return default;
                }

                bool succeeded = await _database.StringSetAsync(cacheKey, value.ToConvertJsonIfNotStringType());
                if (!succeeded)
                {
                    Log.Warning("{@cacheKey} adlı veri redise aktarılamadı.", cacheKey);
                    return default;
                }

                bool succedeed = await _database.KeyExpireAsync(cacheKey, expireTime.Value.AddMinutes(minute));
                if (!succedeed)
                {
                    Log.Warning("{@cacheKey} anahtarın {@minute} dakikalık süresi uzatılamadı.", cacheKey, minute);
                    return default;
                }

                return true;
            });
        }

        public async Task<bool> ExtendCacheKeyTimeAsync(string cacheKey, int minute = 5)
        {
            ValidateCacheKey(cacheKey);

            return await RedisRetryPolicies.AsyncRetryPolicy.ExecuteAsync(async () =>
            {
                if (!await _database.KeyExistsAsync(cacheKey))
                {
                    Log.Warning("{@cacheKey} adlı anahtar bulunamadı.", cacheKey);
                    return default;
                }

                var expireTime = await _database.KeyExpireTimeAsync(cacheKey);
                if (!expireTime.HasValue)
                {
                    Log.Warning("{@cacheKey} adlı anahtar bulunamadı.", cacheKey);
                    return default;
                }

                var succedeed = await _database.KeyExpireAsync(cacheKey, expireTime.Value.AddMinutes(minute));
                if (!succedeed)
                {
                    Log.Warning("{@cacheKey} anahtarın {@minute} dakikalık süresi uzatılamadı.", cacheKey, minute);
                    return default;
                }

                return true;
            });
        }

        public async Task<bool> RemoveAsync(string cacheKey)
        {
            ValidateCacheKey(cacheKey);

            return await RedisRetryPolicies.AsyncRetryPolicy.ExecuteAsync(async () =>
            {
                if (await _database.KeyExistsAsync(cacheKey) && !await _database.KeyDeleteAsync(cacheKey))
                {
                    Log.Warning("Redis de {@cacheKey} anahtarı silinemedi.", cacheKey);
                    return default;
                }

                return true;
            });
        }

        public async Task<bool> RemoveKeysBySearchKeyAsync(string searchKey, KeySearchType keySearchType)
        {
            ValidateSearchKey(searchKey);

            return await RedisRetryPolicies.AsyncRetryPolicy.ExecuteAsync(async () =>
            {
                searchKey = keySearchType switch
                {
                    KeySearchType.EndsWith => $"*{searchKey}",
                    KeySearchType.StartsWith => $"{searchKey}*",
                    KeySearchType.Include => $"*{searchKey}*",
                    _ => $"*{searchKey}*",
                };

                var redisKeys = _server.Keys(_defaultDatabase, searchKey).ToArray();
                if (redisKeys is null || !redisKeys.Any())
                {
                    Log.Information("Redisde aranan {@searchKey} kelimeye ait anahtar veya anahtarlar bulunamadı.", searchKey);
                    return default;
                }

                var totalNumberOfDeletedKeys = await _database.KeyDeleteAsync(redisKeys);
                if (0 >= totalNumberOfDeletedKeys)
                {
                    Log.Error("Redisde aranan {@searchKey} kelimesine ait toplam {@redisKeysCount} adet anahtar bulundu fakat hiçbir anahtar silinemedi.", searchKey, redisKeys.Length);
                    return default;
                }
                else if (totalNumberOfDeletedKeys > 0 && totalNumberOfDeletedKeys != redisKeys.Length)
                {
                    Log.Warning("Redisde aranan {@searchKey} kelimesine ait toplam {@redisKeysCount} adet anahtar bulundu fakat toplam {@totalNumberOfDeletedKeys} anahtar silindi.", searchKey, redisKeys.Length, totalNumberOfDeletedKeys);
                    return true;
                }
                else
                {
                    Log.Information("Redisde aranan {@searchKey} kelimesine ait tüm anahtarlar silindi.", searchKey);
                }

                return true;
            });
        }

        public async ValueTask ClearAppCacheAsync(int databaseNumber = default)
        {
            if (databaseNumber.Equals(default))
                databaseNumber = _defaultDatabase;

            await RedisRetryPolicies.AsyncRetryPolicy.ExecuteAsync(async () =>
            {
                await _server.FlushDatabaseAsync(databaseNumber);
            });
        }

        private static void ValidateCacheKey(string cacheKey)
        {
            if (string.IsNullOrWhiteSpace(cacheKey))
                throw new ArgumentNullException(nameof(cacheKey), ExceptionMessage.CacheKeyRequired);
        }

        private static void ValidateSearchKey(string searchKey)
        {
            if (string.IsNullOrWhiteSpace(searchKey))
                throw new ArgumentNullException(nameof(searchKey), ExceptionMessage.SearchKeyRequired);
        }

        private static void ValidateMemberKey(string memberKey)
        {
            if (string.IsNullOrWhiteSpace(memberKey))
                throw new ArgumentNullException(nameof(memberKey), ExceptionMessage.MemberKeyRequired);
        }
    }
}
