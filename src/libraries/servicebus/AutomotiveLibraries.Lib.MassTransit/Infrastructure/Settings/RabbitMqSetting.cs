namespace AutomotiveBrands.Lib.MassTransit.Infrastructure.Settings
{
    public interface IRabbitMqSetting
    {
        string HostName { get; init; }
        string Username { get; init; }
        string Password { get; init; }
        int RetryCount { get; init; }
    }

    internal sealed record RabbitMqSetting : IRabbitMqSetting
    {
        public string HostName { get; init; }
        public string Username { get; init; }
        public string Password { get; init; }
        public int RetryCount { get; init; }
    }
}
