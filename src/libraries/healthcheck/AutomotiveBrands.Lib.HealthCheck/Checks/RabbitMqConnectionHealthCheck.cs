namespace AutomotiveBrands.Lib.HealthCheck.Checks
{
    internal static class RabbitMqConnectionHealthCheck
    {
        internal static IHealthChecksBuilder AddRabbitMqCheck(this IHealthChecksBuilder healthChecksBuilder)
        {
            healthChecksBuilder.AddRabbitMQ(
                name: "", 
                failureStatus: HealthStatus.Unhealthy,
                tags: new[] { "Rabbitmq", "Event", "Message" });

            return healthChecksBuilder;
        }
    }
}
