using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DD4T.Core.Contracts.Configuration;
using DD4T.Core.Contracts.Caching;
using DD4T.Core.Contracts.Logging;
using DD4T.Core.Contracts.Resolvers;

namespace DD4T.Core.Contracts.Providers
{
    public interface IProviderCommonServices
    {
        
        IPublicationResolverAsync PublicationResolver { get; }
        ILoggerAsync Logger { get; }
        IDD4TConfigurationAsync Configuration { get; }
        ICacheAgentAsync CacheAgent { get;  }
    }
}
