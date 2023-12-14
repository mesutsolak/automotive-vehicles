namespace AutomotiveBrands.UserService.Infrastructure.Mappers
{
    internal static class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazyMapper = new(() =>
        {
            MapperConfiguration mapperConfiguration = new(configuration =>
            {
                configuration.AddProfile<MapProfile>();
            });

            return mapperConfiguration.CreateMapper();
        });

        internal static IMapper Mapper => lazyMapper.Value;
    }
}
