namespace AutomotiveBrands.UserService.Infrastructure.Data.Context
{
    public interface IUserDbContext
    {
        /// <summary>
        /// Tercihler
        /// </summary>
        DbSet<Preference> Preferences { get; set; }
    }
}
