namespace AutomotiveBrands.UserService.Infrastructure.WebHelpers
{
    public partial class WebHelper : IWebHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WebHelper(IServiceProvider serviceProvider)
        {
            _httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
        }

        protected virtual bool IsRequestAvailable()
        {
            if (_httpContextAccessor == null || _httpContextAccessor.HttpContext == null)
                return false;

            try
            {
                if (_httpContextAccessor.HttpContext.Request == null)
                    return false;
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        protected virtual bool IsIpAddressSet(IPAddress address)
        {
            return address != null && address.ToString() != IPAddress.IPv6Loopback.ToString();
        }

        public virtual string GetCurrentIpAddress()
        {
            if (!IsRequestAvailable())
                return string.Empty;

            var result = string.Empty;
            try
            {
                if (_httpContextAccessor.HttpContext.Request.Headers != null)
                {
                    var forwardedHttpHeaderKey = "X-FORWARDED-FOR";

                    var forwardedHeader = _httpContextAccessor.HttpContext.Request.Headers[forwardedHttpHeaderKey];
                    if (!StringValues.IsNullOrEmpty(forwardedHeader))
                        result = forwardedHeader.FirstOrDefault();
                }

                if (string.IsNullOrEmpty(result) && _httpContextAccessor.HttpContext.Connection.RemoteIpAddress != null)
                    result = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            }
            catch
            {
                return string.Empty;
            }

            if (result != null && result.Equals(IPAddress.IPv6Loopback.ToString(), StringComparison.InvariantCultureIgnoreCase))
                result = IPAddress.Loopback.ToString();

            if (IPAddress.TryParse(result ?? string.Empty, out var ip))
                result = ip.ToString();
            else if (!string.IsNullOrEmpty(result))
                result = result.Split(':').FirstOrDefault();

            return result;
        }

        public string IpAddress => GetCurrentIpAddress();
    }
}
