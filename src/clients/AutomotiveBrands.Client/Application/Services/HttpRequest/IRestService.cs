namespace AutomotiveBrands.Client.Application.Services.HttpRequest
{
    public interface IRestService
    {
        /// <summary>
        /// Http get request
        /// </summary>
        /// <typeparam name="TModel">class and new()</typeparam>
        /// <param name="clientName">client name</param>
        /// <param name="routeUrl">route url</param>
        /// <param name="headersCollection">header collection</param>
        /// <returns>type of data result interface</returns>
        /// <exception cref="ArgumentNullException">httpclient or client name is when null</exception>
        TModel GetApiResponse<TModel>(string clientName, string routeUrl, NameValueCollection headersCollection = null) where TModel : class, new();

        /// <summary>
        /// Http get request
        /// </summary>
        /// <typeparam name="TModel">class and new()</typeparam>
        /// <param name="clientName">client name</param>
        /// <param name="routeUrl">route url</param>
        /// <param name="headersCollection">header collection</param>
        /// <returns>type of data result interface</returns>
        /// <exception cref="ArgumentNullException">httpclient or client name is when null</exception>
        Task<TModel> GetApiResponseAsync<TModel>(string clientName, string routeUrl, NameValueCollection headersCollection = null) where TModel : class, new();

        /// <summary>
        /// Http post request
        /// </summary>
        /// <typeparam name="TModel">class and new()</typeparam>
        /// <param name="clientName">client name</param>
        /// <param name="routeUrl">route url</param>
        /// <param name="parameters">parameters</param>
        /// <param name="headersCollection">header collection</param>
        /// <returns>type of data result interface</returns>
        /// <exception cref="ArgumentNullException">httpclient or client name is when null</exception>
        TModel PostApiResponse<TModel>(string clientName, string routeUrl, object parameters, NameValueCollection headersCollection = null) where TModel : class, new();

        /// <summary>
        /// Http post request
        /// </summary>
        /// <typeparam name="TModel">class and new()</typeparam>
        /// <param name="clientName">client name</param>
        /// <param name="routeUrl">route url</param>
        /// <param name="parameters">parameters</param>
        /// <param name="headersCollection">header collection</param>
        /// <returns>type of data result interface</returns>
        /// <exception cref="ArgumentNullException">httpclient or client name is when null</exception>
        Task<TModel> PostApiResponseAsync<TModel>(string clientName, string routeUrl, object parameters, NameValueCollection headersCollection = null) where TModel : class, new();

        /// <summary>
        /// Http post request
        /// </summary>
        /// <typeparam name="TModel">class and new()</typeparam>
        /// <param name="clientName">client name</param>
        /// <param name="routeUrl">route url</param>
        /// <param name="multipartFormDataContent">multipart form data content</param>
        /// <param name="headersCollection">header collection</param>
        /// <returns>type of data result interface</returns>
        /// <exception cref="ArgumentNullException">httpclient or client name is when null</exception>
        TModel PostMultipartDataApiResponse<TModel>(string clientName, string routeUrl, MultipartFormDataContent multipartFormDataContent, NameValueCollection headersCollection = null) where TModel : class, new();

        /// <summary>
        /// Http post request - Multipart form data content
        /// </summary>
        /// <typeparam name="TModel">class and new()</typeparam>
        /// <param name="clientName">client name</param>
        /// <param name="routeUrl">route url</param>
        /// <param name="multipartFormDataContent">multipart form data content</param>
        /// <param name="headersCollection">header collection</param>
        /// <returns>type of data result interface</returns>
        /// <exception cref="ArgumentNullException">httpclient or client name is when null</exception>
        Task<TModel> PostMultipartDataApiResponseAsync<TModel>(string clientName, string routeUrl, MultipartFormDataContent multipartFormDataContent, NameValueCollection headersCollection = null) where TModel : class, new();

        /// <summary>
        /// Http post request - Form Url Encoded Content
        /// </summary>
        /// <typeparam name="TModel">class and new()</typeparam>
        /// <param name="clientName">client name</param>
        /// <param name="routeUrl">route url</param>
        /// <param name="keyValuePairs">key value pairs</param>
        /// <returns>type of data result interface</returns>
        /// <exception cref="ArgumentNullException">httpclient or client name is when null</exception>
        TModel PostEncodedApiResponse<TModel>(string clientName, string routeUrl, IList<KeyValuePair<string, string>> keyValuePairs) where TModel : class, new();

        /// <summary>
        /// Http post request - Form Url Encoded Content
        /// </summary>
        /// <typeparam name="TModel">class and new()</typeparam>
        /// <param name="routeUrl">route url</param>
        /// <param name="keyValuePairs">key value pairs</param>
        /// <returns>type of data result interface</returns>
        /// <exception cref="ArgumentNullException">httpclient or client name is when null</exception>
        Task<TModel> PostEncodedApiResponseAsync<TModel>(string clientName, string routeUrl, IList<KeyValuePair<string, string>> keyValuePairs) where TModel : class, new();
    }
}
