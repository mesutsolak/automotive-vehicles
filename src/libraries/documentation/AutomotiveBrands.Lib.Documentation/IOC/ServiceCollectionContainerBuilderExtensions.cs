namespace AutomotiveBrands.Lib.Documentation.IOC
{
    public static class ServiceCollectionContainerBuilderExtensions
    {
        /// <summary>
        /// Add swagger documentation
        /// </summary>
        /// <param name="services">type of built-in service collection interface</param>
        /// <param name="isBasicSecurityScheme">is basic security scheme</param>
        /// <seealso cref="https://swagger.io/"/>
        /// <returns>type of built-in service collection interface</returns>
        /// <exception cref="ArgumentNullException">when the service provider cannot be built</exception>
        /// <exception cref="InvalidOperationException">if your application settings file does not contain swagger configurations</exception>
        public static IServiceCollection AddSwagger(this IServiceCollection services, bool isBasicSecurityScheme = false)
        {
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            ArgumentNullException.ThrowIfNull(serviceProvider, nameof(serviceProvider));

            IConfiguration configuration = serviceProvider.GetRequiredService<IConfiguration>();
            services.Configure<SwaggerSetting>(configuration.GetRequiredSection(nameof(SwaggerSetting)));
            services.TryAddSingleton<ISwaggerSetting>(provider => provider.GetRequiredService<IOptions<SwaggerSetting>>().Value);

            serviceProvider = services.BuildServiceProvider();
            ArgumentNullException.ThrowIfNull(serviceProvider, nameof(serviceProvider));

            ISwaggerSetting swaggerSetting = serviceProvider.GetRequiredService<ISwaggerSetting>();

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(options =>
            {
                options.DescribeAllParametersInCamelCase();

                options.SwaggerDoc(swaggerSetting.Version,
                    new()
                    {
                        Title = swaggerSetting.Title,
                        Description = swaggerSetting.Description,
                        Version = swaggerSetting.Version,
                        Contact = new()
                        {
                            Email = swaggerSetting.ContactEmail,
                            Name = swaggerSetting.ContactName,
                            Url = new(swaggerSetting.ContactUrl)
                        },
                        License = new()
                        {
                            Name = swaggerSetting.LicenseName,
                            Url = new(swaggerSetting.LicenseUrl)
                        },
                        Extensions = new Dictionary<string, IOpenApiExtension>
                        {
                          {"x-logo", new OpenApiObject
                           {
                              {"url", new OpenApiString("https://www.d-teknoloji.com.tr/assets/img/logo.png")}
                           }
                          }
                        }
                    });

                var xmlFile = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                if (isBasicSecurityScheme)
                {
                    OpenApiSecurityScheme basicSecurityScheme = new()
                    {
                        Type = SecuritySchemeType.Http,
                        Scheme = "basic",
                        Reference = new()
                        {
                            Id = "BasicAuth",
                            Type = ReferenceType.SecurityScheme
                        }
                    };

                    options.AddSecurityDefinition(basicSecurityScheme.Reference.Id, basicSecurityScheme);
                    options.AddSecurityRequirement(new()
                    {
                        { basicSecurityScheme, Array.Empty<string>() },
                    });
                }
            });

            return services;
        }
    }
}
