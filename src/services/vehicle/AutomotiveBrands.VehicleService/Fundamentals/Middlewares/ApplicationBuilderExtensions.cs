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
            app.UseMigrations();
            app.UseSwaggerConfiguration(true);
            app.UseRedoclyConfiguration();
            app.MapDefaultControllerRoute();
            app.UseResponseCompressions();

            return app;
        }
    }
}
