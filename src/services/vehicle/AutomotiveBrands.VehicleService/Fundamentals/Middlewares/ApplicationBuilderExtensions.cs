namespace AutomotiveBrands.VehicleService.Fundamentals.Middlewares
{
    internal static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Use application middlewares
        /// </summary>
        /// <param name="app">type of built-in application builder interface</param>
        /// <returns>type of built-in application builder interface</returns>
        internal static IApplicationBuilder UseApplicationMiddlewares(this WebApplication app)
        {
            app.UseSwaggerConfiguration(true);
            app.UseRedoclyConfiguration();
            app.MapDefaultControllerRoute();

            return app;
        }

        /// <summary>
        /// Those who control the application lifecycle
        /// </summary>
        /// <remarks>OnStarted - OnStopping - OnStopped</remarks>
        /// <param name="app">type of built-in application builder interface</param>
        /// <returns>type of built-in application builder interface</returns>
        internal static IApplicationBuilder UseApplicationLifetimes(this WebApplication app)
        {
            app.SetParametersToRedisDatabase();

            return app;
        }
    }
}
