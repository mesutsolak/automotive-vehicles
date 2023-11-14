namespace AutomotiveBrands.Lib.Cache.Infrastructure.Enums
{
    /// <summary>
    /// Key search type for cache
    /// </summary>
    public enum KeySearchType
    {
        [Description("İle Biter")]
        EndsWith = 1,

        [Description("İle Başlar")]
        StartsWith = 2,

        [Description("İçerir")]
        Include = 3
    }
}
