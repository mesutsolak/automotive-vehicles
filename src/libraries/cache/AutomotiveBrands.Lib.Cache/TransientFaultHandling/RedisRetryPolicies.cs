namespace AutomotiveBrands.Lib.Cache.TransientFaultHandling
{
    internal static class RedisRetryPolicies
    {
        internal static AsyncRetryPolicy AsyncRetryPolicy => RedisRetryAsyncRetryPolicy();
        internal static RetryPolicy RetryPolicy => RedisRetryRetryPolicy();

        private static AsyncRetryPolicy RedisRetryAsyncRetryPolicy()
        {
            return Policy.Handle<Exception>()
                  .WaitAndRetryAsync(2, ComputeDuration, onRetry: (exception, timeSpan, retryCount, context) =>
                  {
                      OnRedisRetry(exception, timeSpan, retryCount, context);
                  });
        }

        private static RetryPolicy RedisRetryRetryPolicy()
        {
            return Policy.Handle<Exception>()
                  .WaitAndRetry(2, ComputeDuration, onRetry: (exception, timeSpan, retryCount, context) =>
                  {
                      OnRedisRetry(exception, timeSpan, retryCount, context);
                  });
        }

        private static void OnRedisRetry(Exception exception, TimeSpan timeSpan, int retryAttempt, Context context)
        {
            var logger = Log.ForContext(typeof(RedisRetryPolicies));
            logger.Error(exception, "Redis iletişiminde hata oluştu. Bir sonraki denemeden önce {@timeSpan} bekleniyor. Yeniden deneme girişimi: {@retryCount}. Context : {@context}", timeSpan, retryAttempt, context);
        }

        private static TimeSpan ComputeDuration(int retryAttempt)
        {
            return TimeSpan.FromSeconds(Math.Pow(2, retryAttempt));
        }
    }
}
