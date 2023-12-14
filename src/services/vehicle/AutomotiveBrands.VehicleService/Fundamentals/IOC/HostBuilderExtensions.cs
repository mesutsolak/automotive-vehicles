namespace AutomotiveBrands.VehicleService.Fundamentals.IOC
{
    internal static class HostBuilderExtensions
    {
        /// <summary>
        /// Add host extensions 
        /// </summary>
        /// <param name="webApplicationBuilder">type of web application builder</param>
        /// <returns>type of web application builder</returns>
        internal static WebApplicationBuilder AddHostExtensions(this WebApplicationBuilder webApplicationBuilder)
        {
            webApplicationBuilder.AddSeriLog(nameof(VehicleDbContext));

            webApplicationBuilder.Host.AddAppConfiguration();
            webApplicationBuilder.Host.AddServiceValidateScope();
            webApplicationBuilder.Host.AddShutdownTimeOut();

            return webApplicationBuilder;
        }
    }
}
