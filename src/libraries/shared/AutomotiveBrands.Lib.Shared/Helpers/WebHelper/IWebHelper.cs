namespace AutomotiveBrands.Lib.Shared.Helpers.WebHelper
{
    public partial interface IWebHelper
    {
        string GetCurrentIpAddress();

        string IpAddress { get; }
    }
}
