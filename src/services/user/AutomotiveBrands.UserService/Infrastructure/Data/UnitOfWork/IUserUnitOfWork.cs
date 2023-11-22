namespace AutomotiveBrands.UserService.Infrastructure.Data.UnitOfWork
{
    public partial interface IUserUnitOfWork : IBaseUnitOfWork
    {
        /// <summary>
        /// Tercihler
        /// </summary>
        IPreferenceRepository Preferences { get; }
    }
}
