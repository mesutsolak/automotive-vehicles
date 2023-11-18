namespace AutomotiveBrands.VehicleService.Fundamentals.Lifetimes
{
    internal static class ParametersCacheApplicationLifetime
    {
        internal static IApplicationBuilder SetParametersToRedisDatabase(this IApplicationBuilder applicationBuilder)
        {

            try
            {
            }
            catch (Exception exception)
            {
                Log.Error(exception, "");
            }
            finally
            {
            }

            return applicationBuilder;
        }

        private static void OnStarted()
        {
        }
    }
}
