using DD4T.ContentModel.Contracts.Configuration;
using DD4T.ContentModel.Contracts.Logging;
using DD4T.ContentModel.Contracts.Providers;
using DD4T.ContentModel.Contracts.Resolvers;
using System;
using System.Net.Http;
using System.Net.Http.Headers;


namespace DD4T.Providers.Rest
{
    public class BaseProvider : IProvider
    {

        private readonly IPublicationResolver PublicationResolver;
        protected readonly ILogger LoggerService;
        protected readonly IDD4TConfiguration Configuration;

        public BaseProvider(IProvidersFacade providersFacade)
        {
            if (providersFacade == null)
                throw new ArgumentNullException("providersFacade");

            LoggerService = providersFacade.Logger;
            PublicationResolver = providersFacade.PublicationResolver;
            Configuration = providersFacade.Configuration;
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
                return response.Content.ReadAsAsync<T>().Result;
            }
            return default(T);
        }
      
    }
}
