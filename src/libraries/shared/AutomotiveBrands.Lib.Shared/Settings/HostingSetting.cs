namespace AutomotiveBrands.Lib.Shared.Settings
{
    public interface IHostingSetting : ISetting
    {
        string ForwardedHttpHeader { get; init; }
    }
    public sealed record HostingSetting : IHostingSetting
    {
        public string ForwardedHttpHeader { get; init; }
    }
}
