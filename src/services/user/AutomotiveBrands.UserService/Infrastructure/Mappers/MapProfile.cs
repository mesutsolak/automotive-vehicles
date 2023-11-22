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
            CreateMap<Preference, CreatePreferenceCommand>().ReverseMap();
            CreateMap<Preference, UpdatePreferenceCommand>().ReverseMap();
            CreateMap<Preference, PreferenceListQueryResult>().ReverseMap();
        }
    }
}
