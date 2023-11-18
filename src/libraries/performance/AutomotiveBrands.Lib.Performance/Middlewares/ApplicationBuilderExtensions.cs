namespace AutomotiveBrands.Lib.Performance.Middlewares
{
    /// <summary>
    /// Application builder extensions
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Use response compression
        /// </summary>
        /// <param name="app">type of application builder</param>
        /// <returns>type of application builder</returns>
        public static IApplicationBuilder UseResponseCompressions(this IApplicationBuilder app)
        {
            return app.UseResponseCompression();
        }
    }
}
