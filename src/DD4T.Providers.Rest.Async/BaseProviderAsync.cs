
using DD4T.Core.Contracts.Configuration;
using DD4T.Core.Contracts.Logging;
using DD4T.Core.Contracts.Providers;
using DD4T.Core.Contracts.Resolvers;
using System;
using System.Net.Http;
using System.Net.Http.Headers;


namespace DD4T.Providers.Rest.Async
{
    public class BaseProviderAsync : IProviderAsync
    {

        private readonly IPublicationResolverAsync PublicationResolver;
        protected readonly ILoggerAsync LoggerService;
        protected readonly IDD4TConfigurationAsync Configuration;

        public BaseProviderAsync(IProviderCommonServices providersCommonServices)
        {
            if (providersCommonServices == null)
                throw new ArgumentNullException("providersCommonServices");

            LoggerService = providersCommonServices.Logger;
            PublicationResolver = providersCommonServices.PublicationResolver;
            Configuration = providersCommonServices.Configuration;
        }

        private int publicationId = 0;
        public int PublicationId
        {
            get
            {
                if (publicationId == 0)
                    return PublicationResolver.ResolvePublicationId();

                return publicationId;
            }
            set
            {
                publicationId = value;
            }
        }


        private HttpClient _client;
        private HttpClient HttpClient
        {
            get
            {
                if (_client == null)
                {
                    _client = new HttpClient();
                    _client.BaseAddress = new Uri(Configuration.ContentProviderEndPoint);
                    // Add an Accept header for JSON format.
                    _client.DefaultRequestHeaders.Accept.Add(
                         new MediaTypeWithQualityHeaderValue("application/json"));
                }
                return _client;
            }
        }

        public T Execute<T>(string urlParameters)
        {  // List data response.
            HttpResponseMessage response = HttpClient.GetAsync(urlParameters).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                //return response.Content.ReadAsAsync<T>().Result;
            }
            return default(T);
        }
      
    }
}
