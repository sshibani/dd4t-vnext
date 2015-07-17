using DD4T.ContentModel.Contracts.Configuration;
using DD4T.ContentModel.Contracts.Providers;
using DD4T.ContentModel.Contracts.Resolvers;
using DD4T.ContentModel.Contracts.Logging;
using System;

namespace DD4T.Providers.Rest
{
    public class ProvidersFacade : IProvidersFacade
    {
        public IPublicationResolver PublicationResolver { get; private set; }
        public ILogger Logger { get; private set; }
        public IDD4TConfiguration Configuration { get; private set; }

        public ProvidersFacade(IPublicationResolver resolver, ILogger logger, IDD4TConfiguration configuration)
        {
            if (resolver == null)
                throw new ArgumentNullException("resolver");

            if (logger == null)
                throw new ArgumentNullException("logger");

            if (configuration == null)
                throw new ArgumentNullException("configuration");

            Logger = logger;
            PublicationResolver = resolver;
            Configuration = configuration;
        }
    }
}