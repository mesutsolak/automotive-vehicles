namespace AutomotiveBrands.Client.Infrastructure.Constants
{
    internal record struct Routes
    {
        internal const string Home = "/";
        internal const string ErrorPage = "/Error/Index";
        internal const string ErrorPageQueryString = "?statusCode={0}";
    }

    internal record struct ControllerNames
    {
        internal const string Error = "Error";
    }

    internal record struct ActionNames
    {
        internal const string Page404 = "Page404";
        internal const string PageError = "PageError";
    }
}
