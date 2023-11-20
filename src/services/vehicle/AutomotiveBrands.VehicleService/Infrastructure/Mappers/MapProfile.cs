namespace AutomotiveBrands.VehicleService.Infrastructure.Mappers
{
    public sealed class MapProfile : Profile
    {
        public MapProfile()
        {
            VehicleMaps();
        }

        private void VehicleMaps()
        {
            CreateMap<Vehicle, VehicleListQueryResult>().ReverseMap();
            CreateMap<VehicleDetail, VehicleDetailQueryResult>().ReverseMap();
        }
    }
}
