namespace AutomotiveBrands.Client.Application.Services.HttpRequest
{
    public sealed class RestService : IRestService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<RestService> _logger;

        public RestService(IHttpClientFactory httpClientFactory, ILogger<RestService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public TModel GetApiResponse<TModel>(string clientName, string routeUrl, NameValueCollection headersCollection = null) where TModel : class, new()
        {
            ValidateClientName(clientName);

            HttpClient httpClient = _httpClientFactory.CreateClient(clientName);
            ArgumentNullException.ThrowIfNull(httpClient);

            if (headersCollection is not null)
            {
                foreach (var key in headersCollection.AllKeys)
                {
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation(key, headersCollection[key]);
                }
            }

            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(routeUrl).Result;
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                _logger.LogWarning("{@routeUrl} adresine istek atıldı fakat olumlu cevap alınamadı. {@httpResponseMessage}", routeUrl, httpResponseMessage);
            }

            return httpResponseMessage.Content.ReadFromJsonAsync<TModel>().Result;
        }

        public async Task<TModel> GetApiResponseAsync<TModel>(string clientName, string routeUrl, NameValueCollection headersCollection = null) where TModel : class, new()
        {
            ValidateClientName(clientName);

            HttpClient httpClient = _httpClientFactory.CreateClient(clientName);
            ArgumentNullException.ThrowIfNull(httpClient);

            if (headersCollection is not null)
            {
                foreach (var key in headersCollection.AllKeys)
                {
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation(key, headersCollection[key]);
                }
            }

            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(routeUrl);
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                _logger.LogWarning("{@routeUrl} adresine istek atıldı fakat olumlu cevap alınamadı. {@httpResponseMessage}", routeUrl, httpResponseMessage);
            }

            return await httpResponseMessage.Content.ReadFromJsonAsync<TModel>();
        }

        public TModel PostApiResponse<TModel>(string clientName, string routeUrl, object parameters, NameValueCollection headersCollection = null) where TModel : class, new()
        {
            ValidateClientName(clientName);

            HttpClient httpClient = _httpClientFactory.CreateClient(clientName);
            ArgumentNullException.ThrowIfNull(httpClient);

            if (headersCollection is not null)
            {
                foreach (var key in headersCollection.AllKeys)
                {
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation(key, headersCollection[key]);
                }
            }

            HttpResponseMessage httpResponseMessage = httpClient.PostAsJsonAsync(routeUrl, parameters).Result;
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                _logger.LogWarning("{@routeUrl} adresine istek atıldı fakat olumlu cevap alınamadı. {@httpResponseMessage}", routeUrl, httpResponseMessage);
            }

            return httpResponseMessage.Content.ReadFromJsonAsync<TModel>().Result;
        }

        public async Task<TModel> PostApiResponseAsync<TModel>(string clientName, string routeUrl, object parameters, NameValueCollection headersCollection = null) where TModel : class, new()
        {
            ValidateClientName(clientName);

            var strParam = JsonConvert.SerializeObject(parameters);
            var stringContent = new StringContent(strParam, Encoding.UTF8, MediaTypeNames.Application.Json);

            HttpClient httpClient = _httpClientFactory.CreateClient(clientName);
            ArgumentNullException.ThrowIfNull(httpClient);

            if (headersCollection is not null)
            {
                foreach (var key in headersCollection.AllKeys)
                {
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation(key, headersCollection[key]);
                }
            }

            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(routeUrl, stringContent);
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                _logger.LogWarning("{@routeUrl} adresine istek atıldı fakat olumlu cevap alınamadı. {@httpResponseMessage}", routeUrl, httpResponseMessage);
            }

            return await httpResponseMessage.Content.ReadFromJsonAsync<TModel>();
        }

        public TModel PostMultipartDataApiResponse<TModel>(string clientName, string routeUrl, MultipartFormDataContent multipartFormDataContent, NameValueCollection headersCollection = null) where TModel : class, new()
        {
            ValidateClientName(clientName);

            HttpClient httpClient = _httpClientFactory.CreateClient(clientName);
            ArgumentNullException.ThrowIfNull(httpClient);

            if (headersCollection is not null)
            {
                foreach (var key in headersCollection.AllKeys)
                {
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation(key, headersCollection[key]);
                }
            }

            HttpResponseMessage httpResponseMessage = httpClient.PostAsync(routeUrl, multipartFormDataContent).Result;
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                _logger.LogWarning("{@routeUrl} adresine istek atıldı fakat olumlu cevap alınamadı. {@httpResponseMessage}", routeUrl, httpResponseMessage);
            }

            return httpResponseMessage.Content.ReadFromJsonAsync<TModel>().Result;
        }

        public async Task<TModel> PostMultipartDataApiResponseAsync<TModel>(string clientName, string routeUrl, MultipartFormDataContent multipartFormDataContent, NameValueCollection headersCollection = null) where TModel : class, new()
        {
            ValidateClientName(clientName);

            HttpClient httpClient = _httpClientFactory.CreateClient(clientName);
            ArgumentNullException.ThrowIfNull(httpClient);

            if (headersCollection is not null)
            {
                foreach (var key in headersCollection.AllKeys)
                {
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation(key, headersCollection[key]);
                }
            }

            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(routeUrl, multipartFormDataContent);
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                _logger.LogWarning("{@routeUrl} adresine istek atıldı fakat olumlu cevap alınamadı. {@httpResponseMessage}", routeUrl, httpResponseMessage);
            }

            return await httpResponseMessage.Content.ReadFromJsonAsync<TModel>();
        }

        public TModel PostEncodedApiResponse<TModel>(string clientName, string routeUrl, IList<KeyValuePair<string, string>> keyValuePairs) where TModel : class, new()
        {
            ValidateClientName(clientName);

            HttpClient httpClient = _httpClientFactory.CreateClient(clientName);
            ArgumentNullException.ThrowIfNull(httpClient);

            using FormUrlEncodedContent content = new(keyValuePairs);
            HttpRequestMessage request = new(HttpMethod.Post, routeUrl) { Content = content };

            HttpResponseMessage httpResponseMessage = httpClient.SendAsync(request).Result;
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                _logger.LogWarning("{@routeUrl} adresine istek atıldı fakat olumlu cevap alınamadı. {@httpResponseMessage}", routeUrl, httpResponseMessage);
            }

            return httpResponseMessage.Content.ReadFromJsonAsync<TModel>().Result;
        }

        public async Task<TModel> PostEncodedApiResponseAsync<TModel>(string clientName, string routeUrl, IList<KeyValuePair<string, string>> keyValuePairs) where TModel : class, new()
        {
            ValidateClientName(clientName);

            HttpClient httpClient = _httpClientFactory.CreateClient(clientName);
            ArgumentNullException.ThrowIfNull(httpClient);

            using FormUrlEncodedContent content = new(keyValuePairs);
            HttpRequestMessage request = new(HttpMethod.Post, routeUrl) { Content = content };

            HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(request);
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                _logger.LogWarning("{@routeUrl} adresine istek atıldı fakat olumlu cevap alınamadı. {@httpResponseMessage}", routeUrl, httpResponseMessage);
            }

            return await httpResponseMessage.Content.ReadFromJsonAsync<TModel>();
        }

        private static void ValidateClientName(string clientName)
        {
            if (string.IsNullOrWhiteSpace(clientName))
                throw new ArgumentNullException(nameof(clientName));
        }
    }
}
