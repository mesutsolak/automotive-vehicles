namespace AutomotiveBrands.Lib.MassTransit.MessageTypes.Commands.Sms
{
    public interface IMessageCommand
    {
        int UserId { get; init; }
        int PlatformType { get; init; }
        string PhoneNumber { get; init; }
        string Message { get; init; }
    }

    public sealed record MessageCommand : IMessageCommand
    {
        public int UserId { get; init; }
        public int PlatformType { get; init; }
        public string PhoneNumber { get; init; }
        public string Message { get; init; }
    }
}
