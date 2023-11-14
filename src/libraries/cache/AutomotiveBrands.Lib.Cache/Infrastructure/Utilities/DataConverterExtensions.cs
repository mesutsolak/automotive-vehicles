namespace AutomotiveBrands.Lib.Cache.Infrastructure.Utilities
{
    internal static class DataConverterExtensions
    {
        internal static string ToConvertJsonIfNotStringType<TModel>(this TModel redisValue)
        {
            ArgumentNullException.ThrowIfNull(redisValue);

            if (typeof(TModel) == typeof(string))
                return (string)Convert.ChangeType(redisValue, typeof(string));

            return JsonSerializer.Serialize(redisValue);
        }
    }
}
