using DD4T.Core.Contracts.Caching;
using DD4T.Core.Contracts.Configuration;
using DD4T.Core.Contracts.Logging;
using DD4T.Core.Contracts.Providers;
using DD4T.Core.Contracts.Resolvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DD4T.Providers.Mock.Async
{
    public class ProviderCommonServices : IProviderCommonServices
    {
        public IPublicationResolverAsync PublicationResolver { get; private set; }
        public ILoggerAsync Logger { get; private set; }
        public IDD4TConfigurationAsync Configuration { get; private set; }


        public ProviderCommonServices(IPublicationResolverAsync resolver, ILoggerAsync logger, IDD4TConfigurationAsync configuration)
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
