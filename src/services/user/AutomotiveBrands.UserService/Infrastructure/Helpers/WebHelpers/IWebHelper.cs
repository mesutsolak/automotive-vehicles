namespace AutomotiveBrands.UserService.Infrastructure.WebHelpers
{
    public partial interface IWebHelper
    {
        string GetCurrentIpAddress();

        string IpAddress { get; }
    }
}
