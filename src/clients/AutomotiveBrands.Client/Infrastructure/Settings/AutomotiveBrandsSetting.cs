namespace AutomotiveBrands.Client.Infrastructure.Settings
{
    public interface IAutomotiveBrandsSetting : ISetting
    {
        string BaseAddress { get; init; }
        int TimeOutInSeconds { get; init; }
    }
    public sealed record AutomotiveBrandsSetting : IAutomotiveBrandsSetting
    {
        public string BaseAddress { get; init; }
        public int TimeOutInSeconds { get; init; }
    }
}
