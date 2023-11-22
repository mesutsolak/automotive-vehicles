namespace AutomotiveBrands.UserService.Infrastructure.Data.Repositories.Preferences
{
    public sealed class PreferenceRepository : EfEntityRepository<Preference>, IPreferenceRepository
    {
        public PreferenceRepository(UserDbContext userDbContext) : base(userDbContext)
        {
        }
    }
}
