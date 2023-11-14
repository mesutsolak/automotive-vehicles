namespace AutomotiveBrands.Lib.Host.Setup
{
    public static class HostBuilderExtensions
    {
        /// <summary>
        /// Add application configuration
        /// </summary>
        /// <param name="hostBuilder">type of built-in host builder interface</param>
        /// <seealso cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting.ihostbuilder?view=dotnet-plat-ext-6.0"/>
        /// <returns>type of built-in host builder interface</returns>
        public static IHostBuilder AddAppConfiguration(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureAppConfiguration((hostBuilderContext, configurationBuilder) =>
            {
                configurationBuilder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                configurationBuilder.AddJsonFile($"appsettings.{hostBuilderContext.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true);
            });

            return hostBuilder;
        }

        /// <summary>
        /// Add service validate scope
        /// </summary>
        /// <param name="hostBuilder">type of built-in host builder interface</param>
        /// <seealso cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.serviceprovideroptions.validatescopes?view=dotnet-plat-ext-6.0"/>
        /// <returns>type of built-in host builder interface</returns>
        public static IHostBuilder AddServiceValidateScope(this IHostBuilder hostBuilder)
        {
            hostBuilder.UseDefaultServiceProvider((hostBuilderContext, serviceProviderOptions) =>
            {
                if (hostBuilderContext.HostingEnvironment.IsProduction())
                {
                    serviceProviderOptions.ValidateScopes = false;
                }
                else
                {
                    serviceProviderOptions.ValidateScopes = true;
                }
            });

            return hostBuilder;
        }

        /// <summary>
        /// Add shut down time out
        /// </summary>
        /// <param name="hostBuilder">type of built-in host builder interface</param>
        /// <seealso cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting.hostoptions.shutdowntimeout?view=dotnet-plat-ext-6.0"/>
        /// <returns>type of built-in host builder interface</returns>
        public static IHostBuilder AddShutdownTimeOut(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureHostOptions(configureOptions =>
            {
                configureOptions.ShutdownTimeout = TimeSpan.FromMinutes(10);
            });

            return hostBuilder;
        }

        /// <summary>
        /// Start project
        /// </summary>
        /// <param name="app">type of web application</param>
        public static async ValueTask StartProjectAsync(this WebApplication app)
        {
            string applicationName = app.Environment.ApplicationName;

            try
            {
                Log.Information("-- Starting web host: {@applicationName} --", applicationName);
                await app.RunAsync();
            }
            catch (Exception exception)
            {
                Log.Fatal(exception, "-- Host terminated unexpectedly. {@applicationName} -- ", applicationName);
                await app.StopAsync();
            }
            finally
            {
                Log.CloseAndFlush();
                await app.DisposeAsync();
            }
        }
    }
}
