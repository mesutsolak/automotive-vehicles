namespace AutomotiveBrands.UserService.Infrastructure.Mappers
{
    public sealed class MapProfile : Profile
    {
        public MapProfile()
        {
            UserMaps();
        }

        private void UserMaps()
        {
            CreateMap<Preference, AddPreferenceCommand>().ReverseMap();
            CreateMap<Preference, PreferenceListQueryResult>().ReverseMap();
        }
    }
}
