namespace AutomotiveBrands.Client.App.Middlewares
{
    public sealed class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IWebHelper _webHelper;


        public ExceptionHandlingMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
        {
            _next = next;
            _webHostEnvironment = serviceProvider.GetRequiredService<IWebHostEnvironment>();
            _webHelper = serviceProvider.GetRequiredService<IWebHelper>();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                HandleException(context, ex);
            }
        }

        private void HandleException(HttpContext context, Exception exception)
        {
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "log-email-template.html");
            var logEmailTemplate = File.ReadAllText(filePath);

            logEmailTemplate = logEmailTemplate.Replace("@IpAddress", _webHelper.IpAddress);
            logEmailTemplate = logEmailTemplate.Replace("@Environment", _webHostEnvironment.EnvironmentName);
            logEmailTemplate = logEmailTemplate.Replace("@Exception", JsonConvert.SerializeObject(exception));
            logEmailTemplate = logEmailTemplate.Replace("@RequestPath", context.Request.Path.ToString());

            var smtpClient = new SmtpClient();
            var message = new MailMessage();

            smtpClient.Host = "smtpdtv2.fw.dteknoloji.com.tr";
            smtpClient.Port = 25;

            message.From = new MailAddress("mesuttsolak@hotmail.com", "Otomotiv Fiyat Listesi Hataları");
            message.To.Add("mesuttsolak@hotmail.com");
            message.Subject = "Otomotiv Fiyat Listesi Hataları";
            message.IsBodyHtml = true;
            message.BodyEncoding = Encoding.UTF8;
            message.SubjectEncoding = Encoding.UTF8;
            message.DeliveryNotificationOptions = DeliveryNotificationOptions.None;
            message.Body = logEmailTemplate;

            smtpClient.Send(message);

            context.Response.Redirect(Routes.ErrorPage);
        }
    }
}
