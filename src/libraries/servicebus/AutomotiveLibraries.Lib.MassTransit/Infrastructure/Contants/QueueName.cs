namespace AutomotiveBrands.Lib.MassTransit.Infrastructure.Contants
{
    public sealed record QueueName
    {
        /// <summary>
        /// Email gönderimlerinin yapıladığı kuyruk
        /// </summary>
        public const string SendEmailQueue = "send-email-notification-service-queue";

        /// <summary>
        /// Sms gönderimlerinin yapıldığı kuyruk
        /// </summary>
        public const string SendSmsQueue = "send-sms-notification-service-queue";

        /// <summary>
        /// Firebase ve Huawei ile bildirimlerin gönderildiği kuyruk
        /// </summary>
        public const string SendNotificationQueue = "send-notification-notification-service-queue";
    }
}
