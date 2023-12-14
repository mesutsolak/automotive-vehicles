namespace AutomotiveBrands.UserService.Infrastructure.Data.UnitOfWork
{
    public sealed class UserUnitOfWork : BaseUnitOfWork, IUserUnitOfWork
    {
        private readonly IServiceProvider _serviceProvider;

        public UserUnitOfWork(
            UserDbContext context,
            IServiceProvider serviceProvider) : base(context)
        {
            _serviceProvider = serviceProvider;
        }

        public IPreferenceRepository Preferences => _serviceProvider.GetRequiredService<IPreferenceRepository>();
    }
}
