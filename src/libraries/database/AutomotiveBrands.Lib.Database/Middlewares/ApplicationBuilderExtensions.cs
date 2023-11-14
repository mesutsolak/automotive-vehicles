namespace AutomotiveBrands.Lib.Database.Middlewares
{
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Add migration endpoint
        /// </summary>
        /// <remarks>entity framework ile veri tabanı hatası aldığınızda devreye girer.</remarks>
        /// <param name="app">type of built-in application builder interface</param>
        /// <returns>type of built-in application builder interface</returns>
        /// <exception cref="InvalidOperationException">If the container cannot invoke the web host environment interface</exception>
        public static IApplicationBuilder UseMigrations(this IApplicationBuilder app)
        {
            IWebHostEnvironment webHostEnvironment = app.ApplicationServices.GetRequiredService<IWebHostEnvironment>();
            if (webHostEnvironment.IsProduction())
                return app;

            app.UseMigrationsEndPoint();

            return app;
        }
    }
}