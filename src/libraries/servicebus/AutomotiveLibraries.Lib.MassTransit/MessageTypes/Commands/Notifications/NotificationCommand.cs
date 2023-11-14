namespace AutomotiveBrands.Lib.MassTransit.MessageTypes.Commands.Notifications
{
    public interface INotificationCommand
    {
        int PlatformType { get; init; }
        string Title { get; init; }
        string Message { get; init; }
        string ImageUrl { get; init; }
        int NotificationType { get; init; }
        object Source { get; init; }
        int NotificationPlatformType { get; init; }
    }

    public sealed record NotificationCommand : INotificationCommand
    {
        public int PlatformType { get; init; }
        public string Title { get; init; }
        public string Message { get; init; }
        public string ImageUrl { get; init; }
        public int NotificationType { get; init; }
        public object Source { get; init; }
        public int NotificationPlatformType { get; init; }
    }
}
