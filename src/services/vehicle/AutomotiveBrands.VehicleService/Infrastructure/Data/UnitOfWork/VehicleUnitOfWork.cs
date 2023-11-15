namespace AutomotiveAPI.UserService.Infrastructure.Data.UnitOfWork
{
    public sealed class VehicleUnitOfWork : BaseUnitOfWork, IVehicleUnitOfWork
    {
        private readonly IServiceProvider _serviceProvider;

        public VehicleUnitOfWork(
            VehicleDbContext context,
            IServiceProvider serviceProvider) : base(context)
        {
            _serviceProvider = serviceProvider;
        }

        public IVehicleRepository Vehicles => _serviceProvider.GetRequiredService<IVehicleRepository>();

        public IVehicleDetailRepository VehicleDetails => _serviceProvider.GetRequiredService<IVehicleDetailRepository>();
    }
}
