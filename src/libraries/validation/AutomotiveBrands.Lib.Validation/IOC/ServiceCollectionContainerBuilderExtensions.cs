namespace AutomotiveBrands.Lib.Validation.IOC
{
    public static class ServiceCollectionContainerBuilderExtensions
    {
        /// <summary>
        /// Add fluent validation
        /// </summary>
        /// <param name="services">type of built-in service collection interface</param>
        /// <seealso cref="https://docs.fluentvalidation.net/en/latest/"/>
        /// <exception cref="ArgumentNullException">when the service provider cannot be built</exception>
        /// <returns>type of built-in service collection interface</returns>
        public static IServiceCollection AddValidation<TAssembyScanner>(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<TAssembyScanner>();
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();

            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr-TR");

            return services;
        }

        /// <summary>
        /// Add api behaviour options
        /// </summary>
        /// <remarks>web api projesine ve/veya controller'ına sahipseniz, ekleyiniz.</remarks>
        /// <param name="services">type of built-in service collection interface</param>
        /// <seealso cref="https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.apibehavioroptions?view=aspnetcore-6.0"/>
        /// <returns>type of built-in service collection interface</returns>
        public static IServiceCollection AddApiBehaviorOptions(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressInferBindingSourcesForParameters = true;

                options.InvalidModelStateResponseFactory = context =>
                {
                    IEnumerable<string> errors = context.ModelState.Values.Where(p => p.Errors.Any())
                                                                          .SelectMany(p => p.Errors)
                                                                          .Select(p => p.ErrorMessage);

                    Log.Warning("-- Validation Error. Errors: {@errors} --", string.Join(",", errors));

                    string error = errors.First();

                    return new OkObjectResult(new
                    {
                        error
                    });
                };
            });

            return services;
        }
    }
}
